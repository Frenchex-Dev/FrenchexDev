﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using TimeSpanParserUtil;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands;

public abstract class AbstractVagrantCommand(
    IProcessStarterFactory processStarterFactory
)
{
    protected readonly IProcessStarterFactory ProcessStarterFactory = processStarterFactory;

    protected async Task<TResponse> StartInternalAsync<TRequest, TResponse>(
        TRequest                          request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , Func<string>                      commandLineBuilder
      , Func<int, TResponse>              responseFactory
    )
    {
        var processContext = CreateProcessExecutionContext(context, commandLineBuilder());

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = responseFactory(process.ExitCode);

        return response;
    }

    protected ProcessExecutionContext CreateProcessExecutionContext(
        IVagrantCommandExecutionContext context
      , string                          arguments
    )
    {
        var processContext = new ProcessExecutionContext(
                                                         context.WorkingDirectory
                                                       , context.VagrantBin
                                                       , arguments
                                                       , context.Environment
                                                       , context.SaveStdOutStream
                                                       , context.SaveStdErrStream);

        return processContext;
    }

    protected static async Task WaitProcessForExitAsync(
        IVagrantCommandExecutionContext context
      , IProcessExecution               process
    )
    {
        if (!string.IsNullOrEmpty(context.Timeout))
        {
            var timeOutMs = TimeSpanParser.Parse(context.Timeout);

            await process.WaitForExitAsync((int)timeOutMs.TotalMilliseconds);
        }
        else
        {
            await process.WaitForExitAsync();
        }
    }

    protected static void PrepareProcess(
        IVagrantCommandExecutionListeners listeners
      , IProcessStarter                   processStarter
    )
    {
        processStarter.AddProcessPreparer(
                                          process =>
                                          {
                                              process.OutputDataReceived += async (
                                                                                _
                                                                              , e
                                                                            ) =>
                                                                            {
                                                                                if (e.Data == null) return;

                                                                                foreach (var listener in listeners.GetStdOutListeners())
                                                                                    await listener(e.Data);
                                                                            };

                                              process.ErrorDataReceived += async (
                                                                               _
                                                                             , e
                                                                           ) =>
                                                                           {
                                                                               if (e.Data == null) return;

                                                                               foreach (var listener in listeners.GetStdErrListeners())
                                                                                   await listener(e.Data);
                                                                           };

                                              return Task.CompletedTask;
                                          });
    }
}
