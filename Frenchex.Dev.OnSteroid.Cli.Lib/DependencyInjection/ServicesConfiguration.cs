using Frenchex.Dev.OnSteroid.Lib.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return new ServicesConfigurationServices().ConfigureServices(services,
            () =>
            {
                
            },
            () =>
            {
                
            });
    }
}