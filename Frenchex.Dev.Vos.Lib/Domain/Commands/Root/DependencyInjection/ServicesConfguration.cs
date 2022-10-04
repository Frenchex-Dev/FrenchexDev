using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Base.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.DependencyInjection;

public static class ServicesConfguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IBaseRequestBuilderFactory, BaseRequestBuilderFactory>()
            .AddTransient<IBaseRequestBuilder, BaseRequestBuilder>()
            ;
    }
}