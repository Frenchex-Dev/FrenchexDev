using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

public interface IConsoleCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IConsoleCommandRequestBuilder Factory();
}