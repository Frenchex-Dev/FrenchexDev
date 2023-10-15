#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

/// <summary>
/// </summary>
public class VagrantHaltCommand(
    IProcessStarterFactory         processStarterFactory
  , IVagrantHaltCommandLineBuilder commandLineBuilder
  , IVagrantHaltResponseBuilder    responseBuilder
) : AbstractVagrantCommand(processStarterFactory), IVagrantHaltCommand
{
    public async Task<IVagrantHaltResponse> StartAsync(
        VagrantHaltRequest                request
      , IVagrantCommandExecutionContext   context
      , IVagrantCommandExecutionListeners listeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return await StartInternalAsync<VagrantHaltRequest, IVagrantHaltResponse>(
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
                                                                                                                        stdErr
                                                                                                                      , stdOut
                                                                                                                      , exitCode
                                                                                                                      , cancellationToken)
                                                                                , cancellationToken);
    }
}
