#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public class VagrantSshCommand(
    IProcessStarterFactory        processExecutor
  , IVagrantSshCommandLineBuilder commandLineBuilder
  , IVagrantSshResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantSshCommand
{
    public async Task<IVagrantSshResponse> StartAsync(
        VagrantSshRequest                 request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantSshRequest, IVagrantSshResponse>(
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
