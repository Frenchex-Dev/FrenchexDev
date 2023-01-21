#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Facade;

public class ConsoleCommandFacade : IConsoleCommandFacade
{
    public ConsoleCommandFacade(
        IConsoleCommand command,
        IConsoleCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IConsoleCommand Command { get; }
    public IConsoleCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IConsoleCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();

    public string GetCliCommandName()
    {
        return "console";
    }
}