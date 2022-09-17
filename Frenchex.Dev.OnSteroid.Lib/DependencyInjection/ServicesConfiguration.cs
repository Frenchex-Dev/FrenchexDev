using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return StaticConfigureServices(services);
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
                        ;
                },
                () =>
                {
                });
    }
}