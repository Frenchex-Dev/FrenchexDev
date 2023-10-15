#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using TimeSpanParserUtil;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

/// <summary>
/// </summary>
/// <param name="processStarterFactory"></param>
public abstract class AbstractVagrantCommand(
    IProcessStarterFactory processStarterFactory
)
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="_"></param>
    /// <param name="context"></param>
    /// <param name="listeners"></param>
    /// <param name="commandLineBuilder"></param>
    /// <param name="responseFactory"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="Exception">A delegate callback throws an exception.</exception>
    protected async Task<TResponse> StartInternalAsync<TRequest, TResponse>(
        TRequest                                               _
      , IVagrantCommandExecutionContext                        context
      , IVagrantCommandExecutionListeners                      listeners
      , Func<string>                                           commandLineBuilder
      , Func<List<string>, List<string>, int, Task<TResponse>> responseFactory
      , CancellationToken                                      cancellationToken = default
    )
    {
        var processContext = CreateProcessExecutionContext(context, commandLineBuilder());

        var processStarter = processStarterFactory.Factory();

        var stdOut = new List<string>();
        var stdErr = new List<string>();

        listeners.AddStdOutListener(
                                    line =>
                                    {
                                        stdOut.Add(line);
                                        return Task.CompletedTask;
                                    });

        listeners.AddStdErrListener(
                                    line =>
                                    {
                                        stdErr.Add(line);
                                        return Task.CompletedTask;
                                    });

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext, cancellationToken);

        try
        {
            await WaitProcessForExitAsync(context, process, cancellationToken);
        }
        catch (TaskCanceledException)
        {
            // silently catch task cancellation
        }

        var response = await responseFactory(stdOut, stdErr, process.ExitCode);

        return response;
    }

    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    protected static ProcessExecutionContext CreateProcessExecutionContext(
        IVagrantCommandExecutionContext context
      , string                          arguments
    )
    {
        var processContext = new ProcessExecutionContext(
                                                         context.WorkingDirectory
                                                       , context.VagrantBin
                                                       , arguments
                                                       , context.Environment
                                                       , true
                                                       , false);

        return processContext;
    }

    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="process"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected static async Task WaitProcessForExitAsync(
        IVagrantCommandExecutionContext context
      , IProcessExecution               process
      , CancellationToken               cancellationToken = default
    )
    {
        if (!string.IsNullOrEmpty(context.Timeout))
        {
            var timeOutMs = TimeSpanParser.Parse(context.Timeout);

            await process.WaitForExitAsync((int)timeOutMs.TotalMilliseconds, cancellationToken);
        }
        else
        {
            await process.WaitForExitAsync(cancellationToken);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="listeners"></param>
    /// <param name="processStarter"></param>
    protected static void PrepareProcess(
        IVagrantCommandExecutionListeners listeners
      , IProcessStarter                   processStarter
    )
    {
        processStarter.AddProcessPreparer(
                                          context =>
                                          {
                                              AddOutputDataReceivedDelegate(listeners);
                                              AddErrorDataReceivedDelegate(listeners);

                                              return Task.CompletedTask;
                                          });
    }

    /// <summary>
    /// </summary>
    /// <param name="listeners"></param>
    private static void AddErrorDataReceivedDelegate(
        IVagrantCommandExecutionListeners listeners
    )
    {
        listeners.AddStdErrListener(
                                    async line =>
                                    {
                                        foreach (var listener in listeners.GetStdErrListeners())
                                            await SilentlyTryCatch(
                                                                   async () =>
                                                                   {
                                                                       // ReSharper disable once EventExceptionNotDocumented
                                                                       await listener(line);
                                                                   });
                                    });
    }

    /// <summary>
    /// </summary>
    /// <param name="listeners"></param>
    private static void AddOutputDataReceivedDelegate(
        IVagrantCommandExecutionListeners listeners
    )
    {
        listeners.AddStdOutListener(
                                    async line =>
                                    {
                                        foreach (var listener in listeners.GetStdOutListeners())
                                            await SilentlyTryCatch(
                                                                   async () =>
                                                                   {
                                                                       // ReSharper disable once EventExceptionNotDocumented
                                                                       await listener(line);
                                                                   });
                                    });
    }

    /// <summary>
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    protected static async Task SilentlyTryCatch(
        Func<Task> function
    )
    {
        try
        {
            await function();
        }
        // ReSharper disable once CatchAllClause
        catch
        {
            // silently ignore
        }
    }
}
