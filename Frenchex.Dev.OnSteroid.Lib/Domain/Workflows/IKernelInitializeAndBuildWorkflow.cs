using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Workflows;

public interface IKernelInitializeAndBuildWorkflow
{
    Task<IKernel> FlowAsync(IKernerlConfiguration kernelConfiguration);
    Task<IKernelBuilderBuildingContext> Initialize(IKernerlConfiguration kernelConfiguration);
    Task<IKernel> Build(IKernelBuilderBuildingContext kernelBuilderBuildingContext);
}