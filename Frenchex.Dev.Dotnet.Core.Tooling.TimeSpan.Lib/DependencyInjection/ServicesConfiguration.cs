using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<ITimeSpanTooling, TimeSpanTooling>()
            ;
    }
}