using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Request;

public class InitCommandRequestBuilderFactory : IInitCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public InitCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IInitCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IInitCommandRequestBuilder>();
    }
}