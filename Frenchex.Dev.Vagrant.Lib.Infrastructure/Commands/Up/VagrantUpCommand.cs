#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Up;

/// <summary>
///     <inheritdoc cref="IVagrantUpCommand" />
/// </summary>
public class VagrantUpCommand(
    IProcessStarterFactory       processStarterFactory
  , IVagrantUpCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processStarterFactory), IVagrantUpCommand
{
    public async Task<UpCommandResponse> StartAsync(
        VagrantUpRequest                  request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        var processContext = CreateProcessExecutionContext(context, commandLineBuilder.BuildCommandLineArguments(request));

        var processStarter = ProcessStarterFactory.Factory();

        PrepareProcess(listeners, processStarter);

        var process = await processStarter.StartAsync(processContext);

        await WaitProcessForExitAsync(context, process);

        var response = new UpCommandResponse(process.ExitCode);

        return response;
    }
}
