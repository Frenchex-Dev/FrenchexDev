using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;

public interface IServicesConfigurationServicesFactory
{
    public IServicesConfigurationServices Factory();
}