#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Facade;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IUpCommand, UpCommand>()
            .AddScoped<IUpFacade, UpFacade>()
            .AddScoped<IUpCommandRequestBuilder, UpCommandRequestBuilder>()
            .AddScoped<IUpCommandRequestBuilderFactory, UpCommandRequestBuilderFactory>()
            .AddScoped<IUpCommandResponseBuilder, UpCommandResponseBuilder>()
            .AddScoped<IUpCommandResponseBuilderFactory, UpCommandResponseBuilderFactory>()
            ;
    }
}