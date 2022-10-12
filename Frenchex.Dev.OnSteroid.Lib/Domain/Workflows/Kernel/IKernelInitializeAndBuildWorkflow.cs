using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;

public interface IKernelInitializeAndBuildWorkflow : IKernelBuildingWorkflow
{
    Task<IKernelBuilderBuildingContext> FactoryContext(
        IServiceCollection serviceCollection,
        IKernerlConfiguration kernelConfiguration
    );

    Task<IKernel> Build(
        IServiceCollection serviceCollection,
        IKernelBuilderBuildingContext kernelBuilderBuildingContext
    );
}