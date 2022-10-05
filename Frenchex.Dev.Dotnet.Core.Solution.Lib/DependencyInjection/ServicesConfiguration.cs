using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.DependencyInjection;

public static class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        ConfigureDependencies(serviceCollection);
    }

    private static void ConfigureDependencies(IServiceCollection serviceCollection)
    {
        Abstractions.DependencyInjection.DependencyInjection.ConfigureServices(serviceCollection);
    }
}