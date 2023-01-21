#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IBuildCommandFacade, BuildCommandFacade>()
            .AddScoped<IBuildCommand, BuildCommand>()
            .AddScoped<IBuildCommandRequestBuilder, BuildCommandRequestBuilder>()
            .AddScoped<IBuildCommandRequestBuilderFactory, BuildCommandRequestBuilderFactory>()
            .AddScoped<IBuildCommandResponseBuilder, BuildCommandResponseBuilder>()
            .AddScoped<IBuildCommandResponseBuilderFactory, BuildCommandResponseBuilderFactory>()
            ;
    }
}