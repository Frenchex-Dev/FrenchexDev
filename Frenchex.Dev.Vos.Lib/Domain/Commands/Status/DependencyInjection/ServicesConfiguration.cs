using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {

        serviceCollection
            .AddScoped<IStatusCommand, StatusCommand>()
            .AddScoped<IStatusCommandFacade, StatusCommandFacade>()
            .AddScoped<IStatusCommandRequestBuilder, StatusCommandRequestBuilder>()
            .AddScoped<IStatusCommandRequestBuilderFactory, StatusCommandRequestBuilderFactory>()
            .AddScoped<IStatusCommandCommandResponseBuilder, StatusCommandCommandResponseBuilder>()
            .AddScoped<IStatusCommandCommandResponseBuilderFactory, StatusCommandCommandResponseBuilderFactory>()

            ;
        
        return serviceCollection;
    }
}