using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Kernel;
using Frenchex.Dev.Vos.Cli;
using Frenchex.Dev.Vos.Cli.DependencyInjection;
using Frenchex.Dev.Vos.Lib.Kernel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// make sure to us e very same ServiceCollection all around
var serviceCollection = new ServiceCollection();

var vosKernelBuilderFlow = new KernelBuilderFlow(new KernelInitializeAndBuildWorkflow(new KernelBuilderBuildingContextFactory()));
await using var vosKernel = await vosKernelBuilderFlow.FlowAsync(serviceCollection);
await using var vosAsyncScope = await vosKernel.CreateScopeAsync();

var servicesConfiguration = new ServicesConfiguration(vosAsyncScope.ServiceProvider.GetRequiredService<IServicesConfigurationServicesFactory>());
await using var kernel = await KernelInitializeAndBuildFlow.StaticFlowAsync(serviceCollection, servicesConfiguration);
await using var scope = await kernel.CreateScopeAsync();
var programBuilder = scope.ServiceProvider.GetRequiredService<IProgramBuilder>();

IProgram BuildProgram(
    string hostSettingsJsonFilename,
    string appSettingsJsonFilename,
    string appDomainDirectory,
    string envVarPrefix,
    string basePath,
    Action<ILoggingBuilder> configureProgramLoggingAction
)
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
            services.AddHostedService<Host>();
            Frenchex.Dev.Dotnet.Core.Cli.Lib.DependencyInjection.ServicesConfiguration
                .StaticConfigureServices(services);
        },
        configureProgramLoggingAction
    );

    return program;
}

await using var program = BuildProgram(
    "Configurations\\hostsettings.json",
    "Configurations\\appsettings.json",
    AppDomain.CurrentDomain.BaseDirectory,
    "FRENCHEXDEV_VOS",
    Directory.GetCurrentDirectory(),
    logging => logging.ClearProviders().AddConsole()
);

await program.RunAsync();