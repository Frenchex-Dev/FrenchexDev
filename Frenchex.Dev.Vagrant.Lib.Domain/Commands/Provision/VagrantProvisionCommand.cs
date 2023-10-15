#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public class VagrantProvisionCommand(
    IProcessStarterFactory              processExecutor
  , IVagrantProvisionCommandLineBuilder commandLineBuilder
  , IVagrantProvisionResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantProvisionCommand
{
    public async Task<IVagrantProvisionResponse> StartAsync(
        VagrantProvisionRequest           request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantProvisionRequest, IVagrantProvisionResponse>(
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
                                                                                                                                  stdOut
                                                                                                                                , stdErr
                                                                                                                                , exitCode
                                                                                                                                , cancellationToken)
                                                                                          , cancellationToken);
    }
}
