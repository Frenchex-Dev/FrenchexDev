using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Facade;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands;

public class CommandsFacade : ICommandsFacade
{
    public CommandsFacade(
        IDestroyFacade destroy,
        IHaltFacade halt,
        IInitFacade init,
        ISshFacade ssh,
        ISshConfigFacade sshConfig,
        IStatusFacade status,
        IUpFacade up
    )
    {
        Destroy = destroy;
        Halt = halt;
        Init = init;
        Ssh = ssh;
        SshConfig = sshConfig;
        Status = status;
        Up = up;
    }

    public IDestroyFacade Destroy { get; init; }
    public IHaltFacade Halt { get; init; }
    public IInitFacade Init { get; init; }
    public ISshFacade Ssh { get; init; }
    public ISshConfigFacade SshConfig { get; init; }
    public IStatusFacade Status { get; init; }
    public IUpFacade Up { get; init; }
}