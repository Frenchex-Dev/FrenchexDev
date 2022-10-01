using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Facade;

public interface
    IConsoleCommandFacade : IFacableCommand, IFacade<IConsoleCommand, IConsoleCommandRequestBuilderFactory,
        IConsoleCommandRequestBuilder>
{
}