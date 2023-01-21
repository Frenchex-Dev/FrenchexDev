#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Kernel;

public class KernelInitializeAndBuildFlow : IKernelInitializeAndBuildFlow
{
    public async Task<IKernel> FlowAsync(
        IServiceCollection services,
        IServicesConfiguration servicesConfiguration
    )
    {
        return await StaticFlowAsync(services, servicesConfiguration);
    }

    public static async Task<IKernel> StaticFlowAsync(
        IServiceCollection services,
        IServicesConfiguration servicesConfiguration
    )
    {
        var flow = new KernelInitializeAndBuildWorkflow(new KernelBuilderBuildingContextFactory());
        IKernel? kernel = await flow.FlowAsync(services, new KernelConfiguration(servicesConfiguration));
        return kernel;
    }
}