using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Request;

public class StatusCommandRequestBuilder : RootCommandRequestBuilder, IStatusCommandRequestBuilder
{
    private string[]? _namesOrIds;

    public StatusCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IStatusCommandRequest Build()
    {
        _namesOrIds ??= Array.Empty<string>();

        return new StatusCommandRequest(
            BaseBuilder.Build(),
            _namesOrIds
        );
    }

    public IStatusCommandRequestBuilder WithNames(string[] namesOrIds)
    {
        _namesOrIds = namesOrIds;
        return this;
    }
}