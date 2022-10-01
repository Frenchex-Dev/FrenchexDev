using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Request;

public class PluginsCommandRequestBuilderFactory : IPluginsCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PluginsCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IPluginsCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IPluginsCommandRequestBuilder>();
    }
}