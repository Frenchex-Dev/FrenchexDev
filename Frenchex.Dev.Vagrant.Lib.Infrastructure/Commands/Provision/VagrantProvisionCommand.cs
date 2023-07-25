#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Provision;

public class VagrantProvisionCommand : AbstractVagrantCommand, IVagrantProvisionCommand
{
    private readonly IVagrantProvisionCommandLineBuilder _commandLineBuilder;

    public VagrantProvisionCommand(
        IProcessStarterFactory              processExecutor
      , IVagrantProvisionCommandLineBuilder commandLineBuilder
    ) : base(processExecutor)
    {
        _commandLineBuilder = commandLineBuilder;
    }

    public async Task<VagrantProvisionResponse> StartAsync(
        VagrantProvisionRequest           request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext
            = CreateProcessExecutionContext(context, _commandLineBuilder.BuildCommandLineArguments(request));

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = new VagrantProvisionResponse(process.ExitCode);

        return response;
    }
}
