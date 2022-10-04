using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Base.Request;

public class BaseRequestBuilderFactory : IBaseRequestBuilderFactory
{
    public IBaseRequestBuilder Factory(object parent)
    {
        return new BaseRequestBuilder().SetParent(parent);
    }
}