using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Request;

public class StatusCommandRequestBuilder : RootCommandRequestBuilder, IStatusCommandRequestBuilder
{
    private string[]? _namesOrIds;

    public StatusCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
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

    public IStatusCommandRequestBuilder WithNamesOrIds(string[] nameOrId)
    {
        _namesOrIds = nameOrId;
        return this;
    }
}