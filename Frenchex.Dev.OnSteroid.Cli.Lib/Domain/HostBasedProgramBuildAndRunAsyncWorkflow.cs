using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;
using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain;

public static class HostBasedProgramBuildAndRunAsyncWorkflow
{
    public async static Task BuildAndRunAsync<T>(
        IServiceCollection serviceCollection,
        IProgramBuilder programBuilder,
        IServicesConfiguration servicesConfiguration,
        Context context
    ) where T : class, IHostedService
    {
        await using var program = await programBuilder
            .BuildAsync<T>(
                serviceCollection,
                serviceCollection =>
                {
                    servicesConfiguration.ConfigureServices(serviceCollection);
                },
                context
            );

        await program.RunAsync();
    }
}