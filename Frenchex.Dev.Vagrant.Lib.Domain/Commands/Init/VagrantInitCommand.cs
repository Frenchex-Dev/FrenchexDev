#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
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
) : AbstractVagrantCommand(processExecutor), IVagrantInitCommand
{
    public async Task<VagrantInitResponse> StartAsync(
        VagrantInitRequest                request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
    )
    {
        return await StartInternalAsync<VagrantInitRequest, VagrantInitResponse>(
                                                                                 request
                                                                               , context
                                                                               , listeners
                                                                               , () => commandLineBuilder.BuildCommandLineArguments(request)
                                                                               , exitCode => new VagrantInitResponse(exitCode));
    }
}
