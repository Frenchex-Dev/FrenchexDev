#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IPluginsCommand, PluginsCommand>()
            .AddScoped<IPluginsCommandFacade, PluginsCommandFacade>()
            .AddScoped<IPluginsCommandRequestBuilder, PluginsCommandRequestBuilder>()
            .AddScoped<IPluginsCommandRequestBuilderFactory, PluginsCommandRequestBuilderFactory>()
            .AddScoped<IPluginsCommandResponseBuilder, PluginsCommandResponseBuilder>()
            .AddScoped<IPluginsCommandResponseBuilderFactory, PluginsCommandResponseBuilderFactory>()
            ;
    }
}