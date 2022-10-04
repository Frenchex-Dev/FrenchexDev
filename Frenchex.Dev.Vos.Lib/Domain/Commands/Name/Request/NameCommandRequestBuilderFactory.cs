using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Request;

public class NameCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, INameCommandRequestBuilderFactory
{
    public NameCommandRequestBuilderFactory(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public INameCommandRequestBuilder Factory()
    {
        return new NameCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}