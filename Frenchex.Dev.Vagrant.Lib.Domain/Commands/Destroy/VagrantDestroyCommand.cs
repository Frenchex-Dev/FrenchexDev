#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

/// <summary>
/// </summary>
public class VagrantDestroyCommand(
    IProcessStarterFactory            processStarterFactory
  , IVagrantDestroyCommandLineBuilder commandLineBuilder
  , IVagrantDestroyResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processStarterFactory), IVagrantDestroyCommand
{
    public async Task<IVagrantDestroyResponse> StartAsync(
        VagrantDestroyRequest             request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantDestroyRequest, IVagrantDestroyResponse>(
                                                                                        request
                                                                                      , context
                                                                                      , listeners
                                                                                      , () => commandLineBuilder
                                                                                            .BuildCommandLineArguments(request)
                                                                                      , async (
                                                                                            stdOut
                                                                                          , stdErr
                                                                                          , exitCode
                                                                                        ) => await responseBuilder.BuildAsync(
                                                                                                                              stdErr
                                                                                                                            , stdOut
                                                                                                                            , exitCode
                                                                                                                            , cancellationToken)
                                                                                      , cancellationToken);
    }
}
