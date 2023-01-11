#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Facade;

public interface
    IHaltCommandFacade : IFacade<IHaltCommand, IHaltCommandRequestBuilderFactory, IHaltCommandRequestBuilder>
{
}