using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        Domain.ServicesConfigurator.Configure(services);
        Infrastructure.ServicesConfigurator.Configure(services);
    }
}