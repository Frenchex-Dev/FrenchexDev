using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {

        serviceCollection
            .AddScoped<IDestroyCommand, DestroyCommand>()
            .AddScoped<IDestroyCommandFacade, DestroyCommandFacade>()
            .AddScoped<IDestroyCommandRequestBuilder, DestroyCommandRequestBuilder>()
            .AddScoped<IDestroyCommandRequestBuilderFactory, DestroyCommandRequestBuilderFactory>()
            .AddScoped<IDestroyCommandCommandResponseBuilder, DestroyCommandCommandResponseBuilder>()
            .AddScoped<IDestroyCommandCommandResponseBuilderFactory, DestroyCommandCommandResponseBuilderFactory>()

            ;
        
        return serviceCollection;
    }
}