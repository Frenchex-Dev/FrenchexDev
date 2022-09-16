using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IFilesystem, Domain.Filesystem>()
            ;

        return services;
    }
}