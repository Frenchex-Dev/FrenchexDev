using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Domain.Commands.Root.Base.Request;
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