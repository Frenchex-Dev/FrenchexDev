using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Base.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IBaseRequestBuilderFactory, BaseRequestBuilderFactory>()
            .AddSingleton<IBaseRequestBuilder, BaseRequestBuilder>()
            ;
    }
}