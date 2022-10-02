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
        IDestroyCommandFacade destroyCommand,
        IHaltCommandFacade haltCommand,
        IInitCommandFacade initCommand,
        ISshFacade ssh,
        ISshConfigFacade sshConfig,
        IStatusFacade status,
        IUpFacade up
    )
    {
        DestroyCommand = destroyCommand;
        HaltCommand = haltCommand;
        InitCommand = initCommand;
        Ssh = ssh;
        SshConfig = sshConfig;
        Status = status;
        Up = up;
    }

    public IDestroyCommandFacade DestroyCommand { get; init; }
    public IHaltCommandFacade HaltCommand { get; init; }
    public IInitCommandFacade InitCommand { get; init; }
    public ISshFacade Ssh { get; init; }
    public ISshConfigFacade SshConfig { get; init; }
    public IStatusFacade Status { get; init; }
    public IUpFacade Up { get; init; }
}