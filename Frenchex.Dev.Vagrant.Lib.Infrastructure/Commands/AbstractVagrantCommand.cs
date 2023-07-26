#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands;

public abstract class AbstractVagrantCommand
{
    protected readonly IProcessStarterFactory ProcessStarterFactory;

    protected AbstractVagrantCommand(
        IProcessStarterFactory processStarterFactory
    )
    {
        ProcessStarterFactory = processStarterFactory;
    }


    protected ProcessExecutionContext CreateProcessExecutionContext(
        IVagrantCommandExecutionContext context
      , string                          arguments
    )
    {
        var processContext = new ProcessExecutionContext(context.WorkingDirectory, context.VagrantBin, arguments
                                                       , context.Environment, context.SaveStdOutStream
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
            var timeOutMs = TimeSpanParserUtil.TimeSpanParser.Parse(context.Timeout);

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
        processStarter.AddProcessPreparer(process =>
                                          {
                                              process.OutputDataReceived += async (
                                                                                _
                                                                              , e
                                                                            ) =>
                                                                            {
                                                                                if (e.Data == null) return;

                                                                                foreach (var listener in listeners
                                                                                             .GetStdOutListeners())
                                                                                    await listener(e.Data);
                                                                            };

                                              process.ErrorDataReceived += async (
                                                                               _
                                                                             , e
                                                                           ) =>
                                                                           {
                                                                               if (e.Data == null) return;

                                                                               foreach (var listener in listeners
                                                                                            .GetStdErrListeners())
                                                                                   await listener(e.Data);
                                                                           };

                                              return Task.CompletedTask;
                                          });
    }
}
