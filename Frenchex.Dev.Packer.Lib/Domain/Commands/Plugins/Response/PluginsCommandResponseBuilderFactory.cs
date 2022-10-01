using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Response;

public class PluginsCommandResponseBuilderFactory : IPluginsCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PluginsCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IPluginsCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IPluginsCommandResponseBuilder>();
    }
}