using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

public interface IKernelBuilderBuildingContextFactory
{
    IKernelBuilderBuildingContext Factory(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    );
}