using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Request;

public class ProvisionCommandRequestBuilderFactory : RootCommandRequestBuilderFactory,
    IProvisionCommandRequestBuilderFactory
{
    public ProvisionCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IProvisionCommandRequestBuilder Factory()
    {
        return new ProvisionCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}