#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<ISshConfigCommand, SshConfigCommand>()
            .AddScoped<ISshConfigCommandFacade, SshConfigCommandFacade>()
            .AddScoped<ISshConfigCommandRequestBuilder, SshConfigCommandRequestBuilder>()
            .AddScoped<ISshConfigCommandRequestBuilderFactory, SshConfigCommandRequestBuilderFactory>()
            .AddScoped<ISshConfigCommandResponseBuilder, SshConfigCommandResponseBuilder>()
            .AddScoped<ISshConfigCommandResponseBuilderFactory, SshConfigCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}