#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IProvisionCommand, ProvisionCommand>()
            .AddScoped<IProvisionCommandFacade, ProvisionCommandFacade>()
            .AddScoped<IProvisionCommandRequestBuilder, ProvisionCommandRequestBuilder>()
            .AddScoped<IProvisionCommandRequestBuilderFactory, ProvisionCommandRequestBuilderFactory>()
            .AddScoped<IProvisionCommandResponseBuilder, ProvisionCommandResponseBuilder>()
            .AddScoped<IProvisionCommandResponseBuilderFactory, ProvisionCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}