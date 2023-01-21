#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Facade;

public interface
    IConsoleCommandFacade : IFacableCommand, IFacade<IConsoleCommand, IConsoleCommandRequestBuilderFactory,
        IConsoleCommandRequestBuilder>
{
}