#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;

public interface IDestroyCommand : IFacableCommand, ICommand<IDestroyCommandRequest, IDestroyCommandResponse>
{
}