#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public class VagrantSshCommand(
    IProcessStarterFactory        processExecutor
  , IVagrantSshCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantSshCommand
{
    public async Task<VagrantSshResponse> StartAsync(
        VagrantSshRequest                 request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantSshRequest, VagrantSshResponse>(
                                                                               request
                                                                             , context
                                                                             , listeners
                                                                             , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                             , exitCode => new VagrantSshResponse(exitCode));
    }
}
