#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

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
            .AddScoped<INameCommandResponseBuilder, NameCommandResponseBuilder>()
            .AddScoped<INameCommandResponseBuilderFactory, NameCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}