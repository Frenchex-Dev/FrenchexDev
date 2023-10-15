#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands;

/// <summary>
/// 
/// </summary>
/// <param name="destroyCommand"></param>
/// <param name="haltCommand"></param>
/// <param name="initCommand"></param>
/// <param name="provisionCommand"></param>
/// <param name="sshCommand"></param>
/// <param name="sshConfigCommand"></param>
/// <param name="statusCommand"></param>
/// <param name="upCommand"></param>
public class VagrantCommandsFacade(
    IVagrantDestroyCommand   destroyCommand
  , IVagrantHaltCommand      haltCommand
  , IVagrantInitCommand      initCommand
  , IVagrantProvisionCommand provisionCommand
  , IVagrantSshCommand       sshCommand
  , IVagrantSshConfigCommand sshConfigCommand
  , IVagrantStatusCommand    statusCommand
  , IVagrantUpCommand        upCommand
) : IVagrantCommandsFacade
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="executionContext"></param>
    /// <param name="executionListeners"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="IVagrantCommandResponse"/></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IVagrantCommandResponse> StartAsync(
        IVagrantCommandRequest            request
      , IVagrantCommandExecutionContext   executionContext
      , IVagrantCommandExecutionListeners executionListeners
      , CancellationToken                 cancellationToken = default
    )
    {
        return request switch
               {
                   VagrantDestroyRequest vagrantDestroyRequest => await destroyCommand.StartAsync(
                                                                                                  vagrantDestroyRequest
                                                                                                , executionContext
                                                                                                , executionListeners
                                                                                                , cancellationToken)
                 , VagrantHaltRequest vagrantHaltRequest => await haltCommand.StartAsync(
                                                                                         vagrantHaltRequest
                                                                                       , executionContext
                                                                                       , executionListeners
                                                                                       , cancellationToken)
                 , VagrantInitRequest vagrantInitRequest => await initCommand.StartAsync(
                                                                                         vagrantInitRequest
                                                                                       , executionContext
                                                                                       , executionListeners
                                                                                       , cancellationToken)
                 , VagrantProvisionRequest vagrantProvisionRequest => await provisionCommand.StartAsync(
                                                                                                        vagrantProvisionRequest
                                                                                                      , executionContext
                                                                                                      , executionListeners
                                                                                                      , cancellationToken)
                 , VagrantSshRequest vagrantSshRequest => await sshCommand.StartAsync(
                                                                                      vagrantSshRequest
                                                                                    , executionContext
                                                                                    , executionListeners
                                                                                    , cancellationToken)
                 , VagrantSshConfigRequest vagrantSshConfigRequest => await sshConfigCommand.StartAsync(
                                                                                                        vagrantSshConfigRequest
                                                                                                      , executionContext
                                                                                                      , executionListeners
                                                                                                      , cancellationToken)
                 , VagrantStatusRequest vagrantStatusRequest => await statusCommand.StartAsync(
                                                                                               vagrantStatusRequest
                                                                                             , executionContext
                                                                                             , executionListeners
                                                                                             , cancellationToken)
                 , VagrantUpRequest vagrantUpRequest => await upCommand.StartAsync(
                                                                                   vagrantUpRequest
                                                                                 , executionContext
                                                                                 , executionListeners
                                                                                 , cancellationToken)
                 , _ => throw new NotImplementedException(
                                                          request.GetType()
                                                                 .FullName)
               };
    }
}
