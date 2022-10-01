using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

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