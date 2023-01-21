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

public class KernelBuilderBuildingContext : IKernelBuilderBuildingContext
{
    public KernelBuilderBuildingContext(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        ServicesCollection = servicesCollection;
        KernelConfiguration = kernelConfiguration;
    }

    private IServiceCollection ServicesCollection { get; }
    private IKernerlConfiguration KernelConfiguration { get; }

    public IKernel Build()
    {
        KernelConfiguration.ServicesConfiguration.ConfigureServices(ServicesCollection);

        return new Kernel(ServicesCollection.BuildServiceProvider());
    }
}