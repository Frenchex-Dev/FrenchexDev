using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Frenchex.Dev.OnSteroid.Cli.Lib.DependencyInjection;
using Frenchex.Dev.OnSteroid.Cli.Lib.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Frenchex.Dev.Vos.Lib.Kernel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IServicesConfiguration = Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection.IServicesConfiguration;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Workflows.Program;

public interface IBuildFlow
{
    public Task<IProgram> BuildAsync<T>(
        IServiceCollection serviceCollection,
        Action<IServiceCollection> registerServices,
        string hostSettingsJsonFilename,
        string appSettingsJsonFilename,
        string currentDomainBaseDirectory,
        string envVarPrefix,
        string basePath
    ) where T : class, IHostedService;
}

public class BuildFlow : IBuildFlow
{
    public async Task<IProgram> BuildAsync<T>(
        IServiceCollection serviceCollection,
        Action<IServiceCollection> registerServices,
        string hostSettingsJsonFilename,
        string appSettingsJsonFilename,
        string currentDomainBaseDirectory,
        string envVarPrefix,
        string basePath
    ) where T : class, IHostedService
    {
        var vosKernelBuilderFlow =
            new KernelBuilderFlow(
                new KernelInitializeAndBuildWorkflow(
                    new KernelBuilderBuildingContextFactory()));

        await using var vosKernel = await vosKernelBuilderFlow.FlowAsync(serviceCollection);
        await using var vosAsyncScope = await vosKernel.CreateScopeAsync();

        var onSteroidCliServicesConfiguration = new ServicesConfiguration();
        await using var kernel =
            await KernelInitializeAndBuildFlow.StaticFlowAsync(serviceCollection, onSteroidCliServicesConfiguration);

        await using var scope = await kernel.CreateScopeAsync();
        var programBuilder = scope.ServiceProvider.GetRequiredService<IProgramBuilder>();

        var program = await BuildProgram(
            programBuilder,
            onSteroidCliServicesConfiguration,
            hostSettingsJsonFilename,
            appSettingsJsonFilename,
            currentDomainBaseDirectory,
            envVarPrefix,
            basePath,
            services =>
            {
                onSteroidCliServicesConfiguration.ConfigureServices(services);
                registerServices.Invoke(services);
            },
            services =>
            {
                services.AddHostedService<T>();
            },
            services =>
            {
                Dotnet.Core.Cli.Lib.DependencyInjection.ServicesConfiguration
                    .StaticConfigureServices(services);
            },
            logging => logging.ClearProviders().AddConsole()
        );

        return program;
    }

    private async static Task<IProgram> BuildProgram(
        IProgramBuilder programBuilder,
        IServicesConfiguration servicesConfiguration,
        string hostSettingsJsonFilename,
        string appSettingsJsonFilename,
        string appDomainDirectory,
        string envVarPrefix,
        string basePath,
        Action<IServiceCollection> registerServices,
        Action<IServiceCollection> registerHostedServices,
        Action<IServiceCollection> registerDependencyServices,
        Action<ILoggingBuilder> configureProgramLoggingAction
    )
    {
        return await Task.Run(() =>
        {
            IProgram program = programBuilder.Build(
                new Context(
                    Path.GetFullPath(hostSettingsJsonFilename, appDomainDirectory),
                    Path.GetFullPath(appSettingsJsonFilename, appDomainDirectory),
                    envVarPrefix,
                    basePath
                ),
                services =>
                {
                    servicesConfiguration.ConfigureServices(services);
                    registerServices.Invoke(services);
                    registerDependencyServices.Invoke(services);
                },
                services =>
                {
                    registerHostedServices.Invoke(services);
                },
                configureProgramLoggingAction
            );

            return program;
        });
    }
}