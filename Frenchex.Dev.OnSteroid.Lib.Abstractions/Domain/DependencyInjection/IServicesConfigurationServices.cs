using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;

public interface IServicesConfigurationServices
{
    public IServiceCollection ConfigureServices(
        IServiceCollection services,
        Action servicesConfiguration,
        Action dependenciesServicesConfiguration
    );
}