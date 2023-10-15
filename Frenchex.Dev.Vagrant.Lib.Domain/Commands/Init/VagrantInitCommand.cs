#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

/// <summary>
/// </summary>
public class VagrantInitCommand(
    IProcessStarterFactory         processExecutor
  , IVagrantInitCommandLineBuilder commandLineBuilder
  , IVagrantInitResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantInitCommand
{
    public async Task<IVagrantInitResponse> StartAsync(
        VagrantInitRequest                request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantInitRequest, IVagrantInitResponse>(
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
