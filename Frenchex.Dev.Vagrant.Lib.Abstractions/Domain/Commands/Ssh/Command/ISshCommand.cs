#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;

public interface ISshCommand : IFacableCommand, ICommand<ISshCommandRequest, ISshCommandResponse>
{
}