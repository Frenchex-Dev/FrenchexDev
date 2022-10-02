namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

public abstract class RootCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    protected readonly IBaseRequestBuilderFactory BaseRequestBuilderFactory;

    protected RootCommandRequestBuilderFactory(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        BaseRequestBuilderFactory = baseRequestBuilderFactory;
    }
}