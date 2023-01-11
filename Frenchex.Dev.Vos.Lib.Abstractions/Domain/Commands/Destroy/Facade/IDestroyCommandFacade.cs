#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Facade;

public interface IDestroyCommandFacade : IFacableCommand,
    IFacade<IDestroyCommand, IDestroyCommandRequestBuilderFactory, IDestroyCommandRequestBuilder>
{
}