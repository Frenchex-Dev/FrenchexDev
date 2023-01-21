#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Frenchex.Dev.OnSteroid.Cli.Lib.DependencyInjection;
using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Kernel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IServicesConfiguration =
    Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection.IServicesConfiguration;

#endregion

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;

public class ProgramBuilder : IProgramBuilder
{
    public async Task<IProgram> BuildAsync<T>(
        IServiceCollection serviceCollection,
        Action<IServiceCollection> registerServices,
        IContext context
    ) where T : class, IHostedService
    {
        var vosKernelBuilderFlow =
            new WorkflowBasedKernelBuilder(
                new KernelInitializeAndBuildWorkflow(
                    new KernelBuilderBuildingContextFactory()));

        await using IKernel? vosKernel = await vosKernelBuilderFlow.Build(serviceCollection);
        await using AsyncServiceScope vosAsyncScope = vosKernel.GetOrCreateAsyncScope();

        var onSteroidCliServicesConfiguration = new ServicesConfiguration();
        var kernelInitializeAndBuildFlow =
            vosAsyncScope.ServiceProvider.GetRequiredService<IKernelInitializeAndBuildFlow>();

        await using IKernel? kernel =
            await kernelInitializeAndBuildFlow.FlowAsync(serviceCollection, onSteroidCliServicesConfiguration);

        await using AsyncServiceScope scope = kernel.GetOrCreateAsyncScope();
        var programBuilder = scope.ServiceProvider.GetRequiredService<IHostBasedProgramBuilder>();

        IProgram? program = await BuildProgram(
            programBuilder,
            onSteroidCliServicesConfiguration,
            context,
            services =>
            {
                onSteroidCliServicesConfiguration.ConfigureServices(services);
                registerServices.Invoke(services);
            },
            services => { services.AddHostedService<T>(); },
            services =>
            {
                Dotnet.Core.Cli.Lib.DependencyInjection.ServicesConfiguration
                    .StaticConfigureServices(services);
            },
            logging => logging.ClearProviders()
        );

        return program;
    }

    private static async Task<IProgram> BuildProgram(
        IHostBasedProgramBuilder hostBasedProgramBuilder,
        IServicesConfiguration servicesConfiguration,
        IContext context,
        Action<IServiceCollection> registerServices,
        Action<IServiceCollection> registerHostedServices,
        Action<IServiceCollection> registerDependencyServices,
        Action<ILoggingBuilder> configureProgramLoggingAction
    )
    {
        return await Task.Run(() =>
        {
            IProgram? program = hostBasedProgramBuilder.Build(
                context,
                services =>
                {
                    servicesConfiguration.ConfigureServices(services);
                    registerServices.Invoke(services);
                    registerDependencyServices.Invoke(services);
                },
                services => { registerHostedServices.Invoke(services); },
                configureProgramLoggingAction
            );

            return program;
        });
    }
}