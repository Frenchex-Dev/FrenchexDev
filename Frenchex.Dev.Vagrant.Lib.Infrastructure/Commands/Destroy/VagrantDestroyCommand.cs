#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Destroy;

/// <summary>
/// </summary>
public class VagrantDestroyCommand(
    IProcessStarterFactory            processStarterFactory
  , IVagrantDestroyCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processStarterFactory), IVagrantDestroyCommand
{
    public async Task<VagrantDestroyResponse> StartAsync(
        VagrantDestroyRequest             request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext
            = CreateProcessExecutionContext(context, commandLineBuilder.BuildCommandLineArguments(request));

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = new VagrantDestroyResponse(process.ExitCode);

        return response;
    }
}
