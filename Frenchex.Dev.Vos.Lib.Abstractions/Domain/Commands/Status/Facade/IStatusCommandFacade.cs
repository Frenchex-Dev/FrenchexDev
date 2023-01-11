#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Facade;

public interface IStatusCommandFacade : IFacableCommand,
    IFacade<IStatusCommand, IStatusCommandRequestBuilderFactory, IStatusCommandRequestBuilder>
{
}