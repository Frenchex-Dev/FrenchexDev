using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        ConfigureExternalDependencies(services);

        Domain.Commands.Build.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Console.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Fix.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Fmt.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Hcl2Upgrade.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Init.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Inspect.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Plugins.DependencyInjection.ServicesConfiguration.ConfigureServices(services);

        return services;
    }

    private static void ConfigureExternalDependencies(IServiceCollection services)
    {
        Dotnet.Core.Filesystem.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(services);

        Dotnet.Core.Process.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(services);
    }
}