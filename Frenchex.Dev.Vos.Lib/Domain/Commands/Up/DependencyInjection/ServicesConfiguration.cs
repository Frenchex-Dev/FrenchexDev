using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {

        serviceCollection
            .AddScoped<IUpCommand, UpCommand>()
            .AddScoped<IUpCommandFacade, UpCommandFacade>()
            .AddScoped<IUpCommandRequestBuilder, UpCommandRequestBuilder>()
            .AddScoped<IUpCommandRequestBuilderFactory, UpCommandRequestBuilderFactory>()
            .AddScoped<IUpCommandResponseBuilder, UpCommandResponseBuilder>()
            .AddScoped<IUpCommandResponseBuilderFactory, UpCommandResponseBuilderFactory>()

            ;
        
        return serviceCollection;
    }
}