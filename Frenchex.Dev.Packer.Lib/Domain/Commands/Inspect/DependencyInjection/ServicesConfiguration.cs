#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IInspectCommand, InspectCommand>()
            .AddScoped<IInspectCommandFacade, InspectCommandFacade>()
            .AddScoped<IInspectCommandRequestBuilder, InspectCommandRequestBuilder>()
            .AddScoped<IInspectCommandRequestBuilderFactory, InspectCommandRequestBuilderFactory>()
            .AddScoped<IInspectCommandResponseBuilder, InspectCommandResponseBuilder>()
            .AddScoped<IInspectCommandResponseBuilderFactory, InspectCommandResponseBuilderFactory>()
            ;
    }
}