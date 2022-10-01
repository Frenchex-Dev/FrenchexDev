using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Request;

public class PluginsCommandRequestBuilder : IPluginsCommandRequestBuilder
{
    public PluginsCommandRequestBuilder(IBaseCommandRequestBuilderFactory baseBuilderFactory)
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IPluginsCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}