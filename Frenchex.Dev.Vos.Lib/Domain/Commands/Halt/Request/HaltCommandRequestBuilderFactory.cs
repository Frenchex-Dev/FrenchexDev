using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Request;

public class HaltCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, IHaltCommandRequestBuilderFactory
{
    public HaltCommandRequestBuilderFactory(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IHaltCommandRequestBuilder Factory()
    {
        return new HaltCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}