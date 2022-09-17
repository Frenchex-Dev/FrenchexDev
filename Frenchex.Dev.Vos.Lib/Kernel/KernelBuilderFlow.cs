using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Frenchex.Dev.Vos.Lib.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

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

    public async Task<IKernel> FlowAsync(IServiceCollection services)
    {
        var servicesConfiguration = new ServicesConfiguration();
        var kernelConfiguration = new KernelConfiguration(servicesConfiguration);

        return await _kernelInitializeAndBuildWorkflow.FlowAsync(services, kernelConfiguration);
    }
}