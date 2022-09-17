using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelConfiguration : IKernerlConfiguration
{
    public KernelConfiguration(IServicesConfiguration servicesConfiguration)
    {
        ServicesConfiguration = servicesConfiguration;
    }

    public IServicesConfiguration ServicesConfiguration { get; }
}