using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Request;

public class ConsoleCommandRequestBuilder : IConsoleCommandRequestBuilder
{
    public ConsoleCommandRequestBuilder(IBaseCommandRequestBuilderFactory baseBuilderFactory)
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IConsoleCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}