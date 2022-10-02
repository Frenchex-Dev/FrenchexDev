namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

public interface IBaseRequestBuilderFactory
{
    IBaseRequestBuilder Factory(object parent);
}

public class BaseRequestBuilderFactory : IBaseRequestBuilderFactory
{
    public IBaseRequestBuilder Factory(object parent)
    {
        return new BaseRequestBuilder().SetParent(parent);
    }
}