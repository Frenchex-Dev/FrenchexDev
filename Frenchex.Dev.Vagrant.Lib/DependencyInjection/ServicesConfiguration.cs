using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        Dotnet.Core.Filesystem.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(services);

        Dotnet.Core.Process.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(services);

        services
            .AddScoped<ICommandsFacade, CommandsFacade>()
            .AddScoped<IBaseCommandRequestBuilderFactory, BaseCommandRequestBuilderFactory>()
            ;

        Domain.Commands.Destroy.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Halt.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Init.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Provision.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Up.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.SshConfig.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Ssh.DependencyInjection.ServicesConfiguration.ConfigureServices(services);
        Domain.Commands.Status.DependencyInjection.ServicesConfiguration.ConfigureServices(services);

        return services;
    }
}