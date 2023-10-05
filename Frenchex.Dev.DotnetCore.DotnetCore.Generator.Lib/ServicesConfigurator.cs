// Licensing please read LICENSE.md

using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib;

public static class ServicesConfigurator
{
    public static void ConfigureServices(
        IServiceCollection services
    )
    {
        Domain.ServicesConfigurator.ConfigureServices(services);
        Infrastructure.ServicesConfigurator.ConfigureServices(services);
    }
}