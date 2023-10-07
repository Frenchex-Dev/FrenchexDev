#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Provision;

public class VagrantProvisionCommand(
    IProcessStarterFactory              processExecutor
  , IVagrantProvisionCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantProvisionCommand
{
    public async Task<VagrantProvisionResponse> StartAsync(
        VagrantProvisionRequest           request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext = CreateProcessExecutionContext(context, commandLineBuilder.BuildCommandLineArguments(request));

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = new VagrantProvisionResponse(process.ExitCode);

        return response;
    }
}
