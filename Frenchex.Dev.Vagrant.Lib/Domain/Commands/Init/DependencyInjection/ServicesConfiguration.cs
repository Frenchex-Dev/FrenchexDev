#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IInitCommand, InitCommand>()
            .AddScoped<IInitCommandFacade, InitCommandFacade>()
            .AddScoped<IInitCommandRequestBuilder, InitCommandRequestBuilder>()
            .AddScoped<IInitCommandRequestBuilderFactory, InitCommandRequestBuilderFactory>()
            .AddScoped<IInitCommandResponseBuilder, InitCommandResponseBuilder>()
            .AddScoped<IInitCommandResponseBuilderFactory, InitCommandResponseBuilderFactory>()
            ;
    }
}