#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

public class VagrantStatusCommand(
    IProcessStarterFactory           processExecutor
  , IVagrantStatusCommandLineBuilder commandLineBuilder
  , IVagrantStatusResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantStatusCommand
{
    public async Task<IVagrantStatusResponse> StartAsync(
        VagrantStatusRequest              request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantStatusRequest, IVagrantStatusResponse>(
                                                                                      request
                                                                                    , context
                                                                                    , listeners
                                                                                    , () => commandLineBuilder.BuildCommandLineArguments(
                                                                                                                                         request)
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
