#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        ConfigureServicesDependencies(serviceCollection);

        serviceCollection
            .AddScoped<ICommandsFacade, CommandsFacade>()
            .AddScoped<IBaseCommandRequestBuilderFactory, BaseCommandRequestBuilderFactory>()
            ;

        Domain.Commands.Destroy.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Halt.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Init.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Provision.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Up.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.SshConfig.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Ssh.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Status.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);

        return serviceCollection;
    }

    private static void ConfigureServicesDependencies(IServiceCollection serviceCollection)
    {
        Dotnet.Core.Filesystem.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(serviceCollection);

        Dotnet.Core.Process.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(serviceCollection);

        Dotnet.Core.Tooling.TimeSpan.Lib.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
    }
}