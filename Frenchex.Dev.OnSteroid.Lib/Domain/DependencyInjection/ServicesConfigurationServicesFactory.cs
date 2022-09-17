using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;

public class ServicesConfigurationServicesFactory : IServicesConfigurationServicesFactory
{
    public IServicesConfigurationServices Factory()
    {
        return new ServicesConfigurationServices();
    }
}