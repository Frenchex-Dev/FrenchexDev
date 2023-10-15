#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;

public class VagrantSshConfigCommand(
    IProcessStarterFactory              processExecutor
  , IVagrantSshConfigCommandLineBuilder commandLineBuilder
  , IVagrantSshConfigResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantSshConfigCommand
{
    public async Task<IVagrantSshConfigResponse> StartAsync(
        VagrantSshConfigRequest           request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantSshConfigRequest, IVagrantSshConfigResponse>(
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
