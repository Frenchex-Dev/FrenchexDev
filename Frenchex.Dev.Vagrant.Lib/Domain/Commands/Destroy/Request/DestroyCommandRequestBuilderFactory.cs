using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;

public class DestroyCommandRequestBuilderFactory : RootCommandRequestBuilderFactory,
    IDestroyCommandRequestBuilderFactory
{
    public DestroyCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IDestroyCommandRequestBuilder Factory()
    {
        return new DestroyCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}