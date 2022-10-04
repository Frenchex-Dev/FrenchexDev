using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Request;

public abstract class RootCommandRequestBuilder : IRootCommandRequestBuilder
{
    protected RootCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory
    )
    {
        if (null == baseRequestBuilderFactory)
        {
            throw new ArgumentNullException(nameof(baseRequestBuilderFactory));
        }

        BaseBuilder = baseRequestBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }
}