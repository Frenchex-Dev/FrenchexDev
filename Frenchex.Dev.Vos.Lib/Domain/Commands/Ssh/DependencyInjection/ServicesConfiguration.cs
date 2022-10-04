﻿using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {

        serviceCollection
            .AddScoped<ISshCommand, SshCommand>()
            .AddScoped<ISshCommandFacade, SshCommandFacade>()
            .AddScoped<ISshCommandRequestBuilder, SshCommandRequestBuilder>()
            .AddScoped<ISshCommandRequestBuilderFactory, SshCommandRequestBuilderFactory>()
            .AddScoped<ISshCommandCommandResponseBuilder, SshCommandCommandResponseBuilder>()
            .AddScoped<ISshCommandCommandResponseBuilderFactory, SshCommandCommandResponseBuilderFactory>()

            ;
        
        return serviceCollection;
    }
}