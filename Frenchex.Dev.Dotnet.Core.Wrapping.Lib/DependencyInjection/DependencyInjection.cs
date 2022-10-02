using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services
                .AddScoped<IBaseCommandRequestBuilderFactory, BaseCommandRequestBuilderFactory>()
            ;
    }
}