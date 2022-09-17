using Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.Domain;
using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Workflows.Program;
using Frenchex.Dev.Vos.Cli;
using Frenchex.Dev.Vos.Cli.Integration.Domain;
using Microsoft.Extensions.DependencyInjection;

// make sure to us e very same ServiceCollection all around
var serviceCollection = new ServiceCollection();

var buildFlow = new BuildFlow();

await using var program = await buildFlow
    .BuildAsync<Host>(
        serviceCollection,
        services =>
        {
            Frenchex.Dev.Vos.Cli.Integration.DependencyInjection.ServicesConfiguration
                .StaticConfigureServices(services);
        },
        "Configurations\\hostsettings.json",
        "Configurations\\appsettings.json",
        AppDomain.CurrentDomain.BaseDirectory,
        "FRENCHEXDEV_VOS",
        Directory.GetCurrentDirectory());

await program.RunAsync();