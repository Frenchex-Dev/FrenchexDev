#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

public interface IUpCommand : IFacableCommand, ICommand<IUpCommandRequest, IUpCommandResponse>
{
}