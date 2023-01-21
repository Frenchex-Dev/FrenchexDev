#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IFixCommand, FixCommand>()
            .AddScoped<IFixCommandFacade, FixCommandFacade>()
            .AddScoped<IFixCommandRequestBuilder, FixCommandRequestBuilder>()
            .AddScoped<IFixCommandRequestBuilderFactory, FixCommandRequestBuilderFactory>()
            .AddScoped<IFixCommandResponseBuilder, FixCommandResponseBuilder>()
            .AddScoped<IFixCommandResponseBuilderFactory, FixCommandResponseBuilderFactory>()
            ;
    }
}