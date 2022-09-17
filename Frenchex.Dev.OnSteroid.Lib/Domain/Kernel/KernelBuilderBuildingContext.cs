using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelBuilderBuildingContext : IKernelBuilderBuildingContext
{
    private IServiceCollection ServicesCollection { get; init; }
    private IKernerlConfiguration KernelConfiguration { get; init; }
    
    public KernelBuilderBuildingContext(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        ServicesCollection = servicesCollection;
        KernelConfiguration = kernelConfiguration;
    }

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