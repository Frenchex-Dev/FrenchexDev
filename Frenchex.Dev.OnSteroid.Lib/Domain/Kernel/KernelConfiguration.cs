using Frenchex.Dev.OnSteroid.Lib.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public interface IKernerlConfiguration
{
    IServicesConfiguration ServicesConfiguration { get; }
}

public class KernelConfiguration : IKernerlConfiguration
{
    public KernelConfiguration(IServicesConfiguration servicesConfiguration)
    {
        ServicesConfiguration = servicesConfiguration;
    }

    public IServicesConfiguration ServicesConfiguration { get; }
}