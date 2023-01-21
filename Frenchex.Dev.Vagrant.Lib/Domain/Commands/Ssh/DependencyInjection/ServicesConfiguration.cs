#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<ISshCommand, SshCommand>()
            .AddScoped<ISshFacade, SshFacade>()
            .AddScoped<ISshCommandRequestBuilderFactory, SshCommandRequestBuilderFactory>()
            .AddScoped<ISshCommandResponseBuilder, SshCommandResponseBuilder>()
            .AddScoped<ISshCommandResponseBuilderFactory, SshCommandResponseBuilderFactory>()
            ;
    }
}