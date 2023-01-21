#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;

public class KernelInitializeAndBuildWorkflow : IKernelInitializeAndBuildWorkflow
{
    private readonly IKernelBuilderBuildingContextFactory _kernelBuilderBuildingContextFactory;
    private IKernelBuilderBuildingContext? _cachedKernelBuilderBuildingContext;

    public KernelInitializeAndBuildWorkflow(
        IKernelBuilderBuildingContextFactory kernelBuilderBuildingContextFactory
    )
    {
        _kernelBuilderBuildingContextFactory = kernelBuilderBuildingContextFactory;
    }

    public async Task<IKernel> FlowAsync(
        IServiceCollection serviceCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        _cachedKernelBuilderBuildingContext ??= await FactoryContext(serviceCollection, kernelConfiguration);
        IKernel? kernel = _cachedKernelBuilderBuildingContext.Build();

        return kernel;
    }

    public Task<IKernelBuilderBuildingContext> FactoryContext(
        IServiceCollection serviceCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        IKernelBuilderBuildingContext? built =
            _kernelBuilderBuildingContextFactory.Factory(serviceCollection, kernelConfiguration);
        return Task.FromResult(built);
    }

    public async Task<IKernel> Build(
        IServiceCollection serviceCollection,
        IKernelBuilderBuildingContext kernelBuilderBuildingContext
    )
    {
        return await Task.Run(kernelBuilderBuildingContext.Build);
    }
}