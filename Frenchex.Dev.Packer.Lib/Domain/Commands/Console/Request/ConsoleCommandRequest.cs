using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Request;

public class ConsoleCommandRequest : IConsoleCommandRequest
{
    public ConsoleCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}