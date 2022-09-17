using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Kernel;

public class KernelInitializeAndBuildFlow : IKernelInitializeAndBuildFlow
{
    public async Task<IKernel> FlowAsync(
        IServiceCollection services,
        IServicesConfiguration servicesConfiguration
    )
    {
        return await StaticFlowAsync(services, servicesConfiguration);
    }

    public async static Task<IKernel> StaticFlowAsync(
        IServiceCollection services,
        IServicesConfiguration servicesConfiguration
    )
    {
        var flow = new KernelInitializeAndBuildWorkflow(new KernelBuilderBuildingContextFactory());
        var kernel = await flow.FlowAsync(services, new KernelConfiguration(servicesConfiguration));
        return kernel;
    }
}