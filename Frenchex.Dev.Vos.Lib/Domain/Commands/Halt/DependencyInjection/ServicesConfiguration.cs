#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IHaltCommand, HaltCommand>()
            .AddScoped<IHaltCommandFacade, HaltCommandFacade>()
            .AddScoped<IHaltCommandRequestBuilder, HaltCommandRequestBuilder>()
            .AddScoped<IHaltCommandRequestBuilderFactory, HaltCommandRequestBuilderFactory>()
            .AddScoped<IHaltCommandResponseBuilder, HaltCommandResponseBuilder>()
            .AddScoped<IHaltCommandResponseBuilderFactory, HaltCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}