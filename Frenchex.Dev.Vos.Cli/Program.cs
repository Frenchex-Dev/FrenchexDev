using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;
using Frenchex.Dev.Vos.Cli;
using Frenchex.Dev.Vos.Cli.Integration.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

// make sure to us e very same ServiceCollection all around
var serviceCollection = new ServiceCollection();

var programBuildFlow = new ProgramBuilder();

await using var program = await programBuildFlow
    .BuildAsync<Host>(
        serviceCollection,
        services =>
        {
            ServicesConfiguration
                .StaticConfigureServices(services);
        },
        "Configurations\\hostsettings.json",
        "Configurations\\appsettings.json",
        AppDomain.CurrentDomain.BaseDirectory,
        "FRENCHEXDEV_VOS",
        Directory.GetCurrentDirectory());

await program.RunAsync();