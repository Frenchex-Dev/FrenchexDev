#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
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
) : AbstractVagrantCommand(processStarterFactory), IVagrantDestroyCommand
{
    public async Task<VagrantDestroyResponse> StartAsync(
        VagrantDestroyRequest             request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantDestroyRequest, VagrantDestroyResponse>(
                                                                                       request
                                                                                     , context
                                                                                     , listeners
                                                                                     , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                                     , exitCode => new VagrantDestroyResponse(exitCode));
    }
}
