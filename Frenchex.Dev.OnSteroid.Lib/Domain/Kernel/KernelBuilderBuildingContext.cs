using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelBuilderBuildingContext : IKernelBuilderBuildingContext
{
    public KernelBuilderBuildingContext(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        ServicesCollection = servicesCollection;
        KernelConfiguration = kernelConfiguration;
    }

    private IServiceCollection ServicesCollection { get; }
    private IKernerlConfiguration KernelConfiguration { get; }

    public IKernel Build()
    {
        KernelConfiguration.ServicesConfiguration.ConfigureServices(ServicesCollection);

        async Task<ServiceProvider> BuildServiceProvider()
        {
            return await Task.Run(() => ServicesCollection.BuildServiceProvider());
        }

        return new Kernel(BuildServiceProvider, KernelConfiguration);
    }
}