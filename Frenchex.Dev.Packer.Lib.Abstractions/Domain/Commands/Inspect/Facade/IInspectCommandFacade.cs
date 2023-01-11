#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Facade;

public interface IInspectCommandFacade : IFacableCommand,
    IFacade<IInspectCommand, IInspectCommandRequestBuilderFactory, IInspectCommandRequestBuilder>
{
}