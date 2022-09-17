using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows;

namespace Frenchex.Dev.Vos.Lib.Kernel;

public class KernelBuilderFlow : IKernelBuilderFlow
{
    private readonly IKernelInitializeAndBuildWorkflow _kernelInitializeAndBuildWorkflow;

    public KernelBuilderFlow(
        IKernelInitializeAndBuildWorkflow kernelInitializeAndBuildWorkflow
    )
    {
        _kernelInitializeAndBuildWorkflow = kernelInitializeAndBuildWorkflow;
    }

    public async Task<IKernel> FlowAsync(
        IKernerlConfiguration kernelConfiguration
    )
    {
        return await _kernelInitializeAndBuildWorkflow.FlowAsync(kernelConfiguration);
    }
}