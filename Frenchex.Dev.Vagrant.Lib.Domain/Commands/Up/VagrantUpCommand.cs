#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

/// <summary>
///     <inheritdoc cref="IVagrantUpCommand" />
/// </summary>
public class VagrantUpCommand(
    IProcessStarterFactory       processStarterFactory
  , IVagrantUpCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processStarterFactory), IVagrantUpCommand
{
    public async Task<VagrantUpResponse> StartAsync(
        VagrantUpRequest                  request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantUpRequest, VagrantUpResponse>(
                                                                             request
                                                                           , context
                                                                           , listeners
                                                                           , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                           , exitCode => new VagrantUpResponse(exitCode));
    }
}
