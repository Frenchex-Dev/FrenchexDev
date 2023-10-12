#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;

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
        return await StartInternalAsync<VagrantUpRequest, UpCommandResponse>(
                                                                             request
                                                                           , context
                                                                           , listeners
                                                                           , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                           , exitCode => new UpCommandResponse(exitCode));
    }
}
