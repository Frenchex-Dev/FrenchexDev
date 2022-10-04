using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

public interface IKernelBuilderBuildingContextFactory
{
    IKernelBuilderBuildingContext Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    );
}