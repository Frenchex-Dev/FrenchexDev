using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public interface IKernelBuilderBuildingContextFactory
{
    KernelBuilderBuildingContext Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    );
}