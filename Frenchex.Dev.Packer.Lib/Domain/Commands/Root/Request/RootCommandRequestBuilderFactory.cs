using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Request;

public abstract class RootCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    protected readonly IBaseCommandRequestBuilderFactory BaseRequestBuilderFactory;

    protected RootCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        BaseRequestBuilderFactory = baseRequestBuilderFactory;
    }
}