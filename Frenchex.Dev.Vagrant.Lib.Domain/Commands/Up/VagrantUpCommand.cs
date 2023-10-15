#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
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
  , IVagrantUpResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processStarterFactory), IVagrantUpCommand
{
    public async Task<IVagrantUpResponse> StartAsync(
        VagrantUpRequest                  request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantUpRequest, IVagrantUpResponse>(
                                                                              request
                                                                            , context
                                                                            , listeners
                                                                            , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                            , async (
                                                                                  stdOut
                                                                                , stdErr
                                                                                , exitCode
                                                                              ) => await responseBuilder.BuildAsync(
                                                                                                                    stdOut
                                                                                                                  , stdErr
                                                                                                                  , exitCode
                                                                                                                  , cancellationToken)
                                                                            , cancellationToken);
    }
}
