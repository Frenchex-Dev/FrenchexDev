using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelBuilderBuildingContextFactory : IKernelBuilderBuildingContextFactory
{
    public IKernelBuilderBuildingContext Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        return new KernelBuilderBuildingContext(servicesCollection, kernelConfiguration);
    }
}