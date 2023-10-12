#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.SshConfig;

public class VagrantSshConfigCommand(
    IProcessStarterFactory              processExecutor
  , IVagrantSshConfigCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantSshConfigCommand
{
    public async Task<VagrantSshConfigResponse> StartAsync(
        VagrantSshConfigRequest           request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantSshConfigRequest, VagrantSshConfigResponse>(
                                                                                           request
                                                                                         , context
                                                                                         , listeners
                                                                                         , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                                         , exitCode => new VagrantSshConfigResponse(exitCode));
    }
}
