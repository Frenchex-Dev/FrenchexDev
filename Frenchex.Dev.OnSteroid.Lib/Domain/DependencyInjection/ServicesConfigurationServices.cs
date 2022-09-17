using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;

public class ServicesConfigurationServices : IServicesConfigurationServices, IDiscoverableServicesConfiguration
{
    public IServiceCollection ConfigureServices(
        IServiceCollection services,
        Action servicesConfiguration,
        Action dependenciesServicesConfiguration
    )
    {
        servicesConfiguration.Invoke();
        dependenciesServicesConfiguration.Invoke();

        return services;
    }
}