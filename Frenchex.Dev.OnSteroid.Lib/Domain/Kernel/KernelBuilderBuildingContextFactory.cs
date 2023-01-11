#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelBuilderBuildingContextFactory : IKernelBuilderBuildingContextFactory
{
    public IKernelBuilderBuildingContext Factory(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        return new KernelBuilderBuildingContext(servicesCollection, kernelConfiguration);
    }
}