#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public class VagrantProvisionCommand(
    IProcessStarterFactory              processExecutor
  , IVagrantProvisionCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantProvisionCommand
{
    public async Task<VagrantProvisionResponse> StartAsync(
        VagrantProvisionRequest           request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantProvisionRequest, VagrantProvisionResponse>(
                                                                                           request
                                                                                         , context
                                                                                         , listeners
                                                                                         , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                                         , exitCode => new VagrantProvisionResponse(exitCode));
    }
}
