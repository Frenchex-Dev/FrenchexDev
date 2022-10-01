using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Response;

public class BuildCommandResponseBuilderFactory : IBuildCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public BuildCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IBuildCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IBuildCommandResponseBuilder>();
    }
}