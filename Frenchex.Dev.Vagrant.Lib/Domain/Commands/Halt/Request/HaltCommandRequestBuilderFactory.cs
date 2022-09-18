using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Request;

public class HaltCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, IHaltCommandRequestBuilderFactory
{
    public HaltCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IHaltCommandRequestBuilder Factory()
    {
        return new HaltCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}