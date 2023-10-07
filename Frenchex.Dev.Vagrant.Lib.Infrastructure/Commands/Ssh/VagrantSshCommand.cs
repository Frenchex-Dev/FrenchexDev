#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Ssh;

public class VagrantSshCommand(
    IProcessStarterFactory        processExecutor
  , IVagrantSshCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantSshCommand
{
    public async Task<VagrantSshResponse> StartAsync(
        VagrantSshRequest                 request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext = CreateProcessExecutionContext(context, commandLineBuilder.BuildCommandLineArguments(request));

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = new VagrantSshResponse(process.ExitCode);

        return response;
    }
}