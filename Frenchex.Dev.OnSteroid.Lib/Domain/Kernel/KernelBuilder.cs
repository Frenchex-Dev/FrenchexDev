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

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelBuilder : IKernelBuilder
{
    private readonly IKernelBuilderBuildingContextFactory _kernelBuilderBuildingContextFactory;

    public KernelBuilder(
        IKernelBuilderBuildingContextFactory kernelBuilderBuildingContextFactory
    )
    {
        _kernelBuilderBuildingContextFactory = kernelBuilderBuildingContextFactory;
    }

    public async Task<IKernel> Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        return await Task.Run(() =>
        {
            IKernelBuilderBuildingContext? buildingContext =
                _kernelBuilderBuildingContextFactory.Factory(servicesCollection, kernelConfiguration);
            IKernel? builtKernel = buildingContext.Build();

            return builtKernel;
        });
    }
}