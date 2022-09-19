using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Facade;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;

public interface ICommandsFacade
{
    IDestroyFacade Destroy { get; init; }
    IHaltFacade Halt { get; init; }
    IInitFacade Init { get; init; }
    ISshFacade Ssh { get; init; }
    ISshConfigFacade SshConfig { get; init; }
    IStatusFacade Status { get; init; }
    IUpFacade Up { get; init; }
}