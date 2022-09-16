using Frenchex.Dev.Dotnet.Cli.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Frenchex.Dev.Vos.Cli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

await using var executionContext = new ExecutionContextBuilder().Build();

await executionContext.Services.GetRequiredService<IBuilder>()
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
        "FRENCHEXDEV_VOS",
        AppDomain.CurrentDomain.BaseDirectory
    )
    .RunAsync();