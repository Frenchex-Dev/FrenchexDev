#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Destroy;

/// <summary>
/// </summary>
public class VagrantDestroyCommand : AbstractVagrantCommand, IVagrantDestroyCommand
{
    private readonly IVagrantDestroyCommandLineBuilder _commandLineBuilder;

    public VagrantDestroyCommand(
        IProcessStarterFactory         processStarterFactory
      , IVagrantDestroyCommandLineBuilder commandLineBuilder
    ) : base(processStarterFactory)
    {
        _commandLineBuilder = commandLineBuilder;
    }

    public async Task<VagrantDestroyResponse> StartAsync(
        VagrantDestroyRequest                request
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


        var response = new VagrantDestroyResponse(process.ExitCode);

        return response;
    }
}
