#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

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
            .AddScoped<IStatusCommandResponseBuilder, StatusCommandResponseBuilder>()
            .AddScoped<IStatusCommandResponseBuilderFactory, StatusCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}