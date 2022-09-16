using Frenchex.Dev.Dotnet.Cli.Lib.Domain;
using Frenchex.Dev.Vos.Cli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

await Builder
    .Build(
        services =>
        {
            services.AddHostedService<Host>();
            new ServicesConfiguration()
                .ConfigureServices(services);
        },
        logging => logging.ClearProviders().AddConsole(),
        "Configurations\\hostsettings.json",
        "Configurations\\appsettings.json",
        "FRENCHEXDEV_",
        AppDomain.CurrentDomain.BaseDirectory
    )
    .RunAsync();