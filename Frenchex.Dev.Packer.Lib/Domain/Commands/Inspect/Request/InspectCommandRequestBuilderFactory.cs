using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Request;

public class InspectCommandRequestBuilderFactory : IInspectCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public InspectCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IInspectCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IInspectCommandRequestBuilder>();
    }
}