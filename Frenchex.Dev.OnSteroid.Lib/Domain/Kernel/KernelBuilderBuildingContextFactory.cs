using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelBuilderBuildingContextFactory : IKernelBuilderBuildingContextFactory
{
    public KernelBuilderBuildingContext Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        return new KernelBuilderBuildingContext(servicesCollection, kernelConfiguration);
    }
}