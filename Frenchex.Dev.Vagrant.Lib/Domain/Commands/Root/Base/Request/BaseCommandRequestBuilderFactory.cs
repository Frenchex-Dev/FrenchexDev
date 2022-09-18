using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilderFactory : IBaseCommandRequestBuilderFactory
{
    public IBaseCommandRequestBuilder Factory(object parent)
    {
        return new BaseCommandRequestBuilder(parent);
    }
}