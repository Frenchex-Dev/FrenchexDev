#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Facade;

public interface ISshFacade : IFacade<ISshCommand, ISshCommandRequestBuilderFactory, ISshCommandRequestBuilder>
{
}