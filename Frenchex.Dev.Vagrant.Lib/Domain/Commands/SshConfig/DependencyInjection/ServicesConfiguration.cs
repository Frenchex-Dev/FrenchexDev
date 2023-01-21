#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<ISshConfigCommand, SshConfigCommand>()
            .AddScoped<ISshConfigFacade, SshConfigFacade>()
            .AddScoped<ISshConfigCommandRequestBuilder, SshConfigCommandRequestBuilder>()
            .AddScoped<ISshConfigCommandRequestBuilderFactory, SshConfigCommandRequestBuilderFactory>()
            .AddScoped<ISshConfigCommandResponseBuilder, SshConfigCommandResponseBuilder>()
            .AddScoped<ISshConfigCommandResponseBuilderFactory, SshConfigCommandResponseBuilderFactory>()
            ;
    }
}