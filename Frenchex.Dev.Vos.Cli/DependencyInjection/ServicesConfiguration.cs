using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Cli.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration, IDiscoverableServicesConfiguration
{
    private readonly IServicesConfigurationServicesFactory _servicesConfigurationServicesFactory;

    public ServicesConfiguration(
        IServicesConfigurationServicesFactory servicesConfigurationServicesFactory
    )
    {
        _servicesConfigurationServicesFactory = servicesConfigurationServicesFactory;
    }

    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return StaticConfigureServices(services, _servicesConfigurationServicesFactory.Factory());
    }

    public static IServiceCollection StaticConfigureServices(
        IServiceCollection services,
        IServicesConfigurationServices servicesConfigurationServices
    )
    {
        return servicesConfigurationServices
            .ConfigureServices(services,
                () =>
                {
                    services.AddHostedService<Host>();
                },
                () =>
                {
                    Integration.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                    Dotnet.Core.Cli.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                    OnSteroid.Cli.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                });
    }
}