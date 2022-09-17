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
            .AddTransient<IProgramBuilder, ProgramBuilder>()
            .AddTransient<IHostConfigurationConfiguration, HostConfigurationConfiguration>()
            .AddTransient<IAppConfigurationConfiguration, AppConfigurationConfiguration>()
            .AddTransient<IHostBuilder, HostBuilder>()
            .AddTransient<IEntrypointInfo, SystemEnvironmentEntrypointInfo>()
            .AddTransient<IServicesConfiguration, ServicesConfiguration>()
            ;
    }
}