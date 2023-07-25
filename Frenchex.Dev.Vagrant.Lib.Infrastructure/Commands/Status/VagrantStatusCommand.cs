#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Status;

public class VagrantStatusCommand : AbstractVagrantCommand, IVagrantStatusCommand
{
    private readonly IVagrantStatusCommandLineBuilder _commandLineBuilder;

    public VagrantStatusCommand(
        IProcessStarterFactory processExecutor
      , IVagrantStatusCommandLineBuilder commandLineBuilder
    ) : base(processExecutor)
    {
        _commandLineBuilder = commandLineBuilder;
    }

    public async Task<VagrantStatusResponse> StartAsync(
        VagrantStatusRequest request
      , IVagrantCommandExecutionContext context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext
            = CreateProcessExecutionContext(context, _commandLineBuilder.BuildCommandLineArguments(request));

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = new VagrantStatusResponse(process.ExitCode);

        return response;
    }
}
