#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Halt;

/// <summary>
/// </summary>
public class VagrantHaltCommand(
    IProcessStarterFactory         processStarterFactory
  , IVagrantHaltCommandLineBuilder commandLineBuilder
) : AbstractVagrantCommand(processStarterFactory), IVagrantHaltCommand
{
    public async Task<VagrantHaltResponse> StartAsync(
        VagrantHaltRequest                request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantHaltRequest, VagrantHaltResponse>(
                                                                                 request
                                                                               , context
                                                                               , listeners
                                                                               , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                               , exitCode => new VagrantHaltResponse(exitCode));
    }
}
