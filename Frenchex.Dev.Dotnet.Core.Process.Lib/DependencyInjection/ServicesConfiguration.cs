using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddLogging();

        serviceCollection
            .AddScoped<IProcessBuilder, AsyncProcessBuilder>()
            ;

        ConfigureDependencies(serviceCollection);
    }

    private static void ConfigureDependencies(IServiceCollection serviceCollection)
    {
        Tooling.TimeSpan.Lib.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
    }
}