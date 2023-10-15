#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Infrastructure;

public class ProcessStarter : IProcessStarter
{
    private readonly List<Func<IProcessExecutionContext, Task>> _processPreparers = new();

    public void AddProcessPreparer(
        Func<IProcessExecutionContext, Task> processPreparer
    )
    {
        _processPreparers.Add(processPreparer);
    }

    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IProcessExecution> StartAsync(
        IProcessExecutionContext context
      , CancellationToken        cancellationToken = default
    )
    {
        foreach (var preparer in _processPreparers) await preparer(context);

        var process = BuildProcessInternal(context);

        BranchDelegates(context, process);

        var        started           = false;
        Exception? startingException = null;

        try
        {
            started = process.Start();
        }
        // ReSharper disable once CatchAllClause
        catch (Exception ex)
        {
            startingException = ex;
        }

        if (started && context.GetStdErrListeners()
                              .Count > 0)
            process.BeginErrorReadLine();

        if (started && context.GetStdOutListeners()
                              .Count > 0)
            process.BeginOutputReadLine();

        var processExecution = new ProcessExecution(process, started, startingException);

        return processExecution;
    }

    private static void BranchDelegates(
        IProcessExecutionContext   context
      , System.Diagnostics.Process process
    )
    {
        foreach (var stdErrListener in context.GetStdErrListeners())
            process.ErrorDataReceived += async (
                                             sender
                                           , args
                                         ) =>
                                         {
                                             if (args.Data == null) return;
                                             try
                                             {
                                                 await stdErrListener(args.Data);
                                             }
                                             // ReSharper disable once CatchAllClause
                                             catch
                                             {
                                                 // silently ignore
                                             }
                                         };

        foreach (var stdOutListener in context.GetStdOutListeners())
            process.OutputDataReceived += async (
                                              sender
                                            , args
                                          ) =>
                                          {
                                              if (args.Data == null) return;
                                              try
                                              {
                                                  await stdOutListener(args.Data);
                                              }
                                              // ReSharper disable once CatchAllClause
                                              catch
                                              {
                                                  // silently ignore
                                              }
                                          };
    }

    private static System.Diagnostics.Process BuildProcessInternal(
        IProcessExecutionContext context
    )
    {
        return new System.Diagnostics.Process
               {
                   StartInfo =
                   {
                       WorkingDirectory = context.WorkingDirectory
                     , FileName         = context.Binary
                     , Arguments        = context.Arguments
                     , CreateNoWindow   = context.CreateNoWindow
                     , UseShellExecute  = context.UseShellExecute
                     , RedirectStandardError = context.GetStdErrListeners()
                                                      .Count > 0
                     , RedirectStandardInput = true
                     , RedirectStandardOutput = context.GetStdOutListeners()
                                                       .Count > 0
                   }
               };
    }
}
