using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Response;

public interface IConsoleCommandResponseBuilder : IRootCommandResponseBuilder
{
    IConsoleCommandResponse Build();
}