using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {

        serviceCollection
            .AddScoped<INameCommand, NameCommand>()
            .AddScoped<INameCommandFacade, NameCommandFacade>()
            .AddScoped<INameCommandRequestBuilder, NameCommandRequestBuilder>()
            .AddScoped<INameCommandRequestBuilderFactory, NameCommandRequestBuilderFactory>()
            .AddScoped<INameCommandCommandResponseBuilder, NameCommandCommandResponseBuilder>()
            .AddScoped<INameCommandCommandResponseBuilderFactory, NameCommandCommandResponseBuilderFactory>()

            ;
        
        return serviceCollection;
    }
}