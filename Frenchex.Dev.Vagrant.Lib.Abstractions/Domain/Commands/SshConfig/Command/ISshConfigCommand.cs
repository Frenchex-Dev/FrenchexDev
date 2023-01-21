#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;

public interface ISshConfigCommand : IFacableCommand, ICommand<ISshConfigCommandRequest, ISshConfigCommandResponse>
{
}