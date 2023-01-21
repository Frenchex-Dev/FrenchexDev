#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

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
            .AddScoped<ISshCommandResponseBuilder, SshCommandResponseBuilder>()
            .AddScoped<ISshCommandResponseBuilderFactory, SshCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}