using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public void ConfigureServices(IServiceCollection services)
    {
        StaticConfigureServices(services);
    }

    public static void StaticConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<IHostBasedProgramBuilder, HostBasedHostBasedProgramBuilder>()
            .AddSingleton<IHostConfigurationConfiguration, HostConfigurationConfiguration>()
            .AddSingleton<IAppConfigurationConfiguration, AppConfigurationConfiguration>()
            .AddTransient<IHostBuilder, HostBuilder>()
            .AddTransient<IEntrypointInfo, SystemEnvironmentEntrypointInfo>()
            .AddTransient<IServicesConfiguration, ServicesConfiguration>()
            ;
    }
}