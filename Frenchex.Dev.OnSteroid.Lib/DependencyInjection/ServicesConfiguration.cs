#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Kernel;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        return StaticConfigureServices(serviceCollection);
    }

    public static IServiceCollection StaticConfigureServices(IServiceCollection services)
    {
        return new ServicesConfigurationServices()
            .ConfigureServices(services,
                () =>
                {
                    services
                        .AddScoped<IServicesConfigurationServices, ServicesConfigurationServices>()
                        .AddScoped<IKernelBuilder, KernelBuilder>()
                        .AddScoped<IKernelBuilderBuildingContextFactory, KernelBuilderBuildingContextFactory>()
                        .AddScoped<IKernelInitializeAndBuildWorkflow, KernelInitializeAndBuildWorkflow>()
                        .AddScoped<IServicesConfigurationServicesFactory, ServicesConfigurationServicesFactory>()
                        .AddScoped<IKernelInitializeAndBuildFlow, KernelInitializeAndBuildFlow>()
                        ;
                },
                () => { });
    }
}