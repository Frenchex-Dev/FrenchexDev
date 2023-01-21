#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Facade;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;

public interface ICommandsFacade
{
    IDestroyCommandFacade DestroyCommand { get; init; }
    IHaltCommandFacade HaltCommand { get; init; }
    IInitCommandFacade InitCommand { get; init; }
    ISshFacade Ssh { get; init; }
    ISshConfigFacade SshConfig { get; init; }
    IStatusFacade Status { get; init; }
    IUpFacade Up { get; init; }
}