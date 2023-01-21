#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Facade;

public interface INameCommandFacade : IFacableCommand,
    IFacade<INameCommand, INameCommandRequestBuilderFactory, INameCommandRequestBuilder>
{
}