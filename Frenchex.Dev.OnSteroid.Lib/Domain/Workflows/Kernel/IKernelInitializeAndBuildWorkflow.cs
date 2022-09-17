using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;

public interface IKernelInitializeAndBuildWorkflow
{
    Task<IKernel> FlowAsync(IServiceCollection serviceCollection, IKernerlConfiguration kernelConfiguration);

    Task<IKernelBuilderBuildingContext> Initialize(
        IServiceCollection serviceCollection,
        IKernerlConfiguration kernelConfiguration
    );

    Task<IKernel> Build(
        IServiceCollection serviceCollection,
        IKernelBuilderBuildingContext kernelBuilderBuildingContext
    );
}