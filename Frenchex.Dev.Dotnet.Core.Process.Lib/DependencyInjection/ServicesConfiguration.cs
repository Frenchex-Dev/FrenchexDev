using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.DependencyInjection;

public class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();

        services
            .AddScoped<IProcessBuilder, AsyncProcessBuilder>()
            ;
    }
}