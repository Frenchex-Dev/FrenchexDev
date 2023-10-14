#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

public class VagrantStatusCommand(
    IProcessStarterFactory           processExecutor
  , IVagrantStatusCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processExecutor), IVagrantStatusCommand
{
    public async Task<VagrantStatusResponse> StartAsync(
        VagrantStatusRequest              request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantStatusRequest, VagrantStatusResponse>(
                                                                                     request
                                                                                   , context
                                                                                   , listeners
                                                                                   , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                                   , exitCode => new VagrantStatusResponse(exitCode));
    }
}
