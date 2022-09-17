using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Workflows.Program;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return StaticConfigureServices(services);
    }

    public static IServiceCollection StaticConfigureServices(IServiceCollection services)
    {
        return new ServicesConfigurationServices().ConfigureServices(services,
            () =>
            {
                services
                    .AddScoped<IBuildFlow, BuildFlow>()
                    ;
            },
            () =>
            {
                OnSteroid.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                Dotnet.Core.Cli.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
            });
    }
}