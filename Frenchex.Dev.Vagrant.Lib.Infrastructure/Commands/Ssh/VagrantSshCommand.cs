#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Ssh;

public class VagrantSshCommand : AbstractVagrantCommand, IVagrantSshCommand
{
    private readonly IVagrantSshCommandLineBuilder _commandLineBuilder;

    public VagrantSshCommand(
        IProcessStarterFactory        processExecutor
      , IVagrantSshCommandLineBuilder commandLineBuilder
    ) : base(processExecutor)
    {
        _commandLineBuilder = commandLineBuilder;
    }

    public async Task<VagrantSshResponse> StartAsync(
        VagrantSshRequest                 request
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

        var response = new VagrantSshResponse(process.ExitCode);

        return response;
    }
}
