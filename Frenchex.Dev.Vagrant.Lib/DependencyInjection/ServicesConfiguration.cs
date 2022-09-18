using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Response;
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
            ;

        services
            .AddScoped<IBaseCommandRequestBuilderFactory, BaseCommandRequestBuilderFactory>()
            .AddScoped<IDestroyCommand, DestroyCommand>()
            .AddScoped<IDestroyCommandRequestBuilder, DestroyCommandRequestBuilder>()
            .AddScoped<IDestroyCommandRequestBuilderFactory, DestroyCommandRequestBuilderFactory>()
            .AddScoped<IDestroyCommandResponseBuilder, DestroyCommandResponseBuilder>()
            .AddScoped<IDestroyCommandResponseBuilderFactory, DestroyCommandResponseBuilderFactory>()
            .AddScoped<IHaltCommand, HaltCommand>()
            .AddScoped<IHaltCommandRequestBuilder, HaltCommandRequestBuilder>()
            .AddScoped<IHaltCommandRequestBuilderFactory, HaltCommandRequestBuilderFactory>()
            .AddScoped<IHaltCommandResponseBuilder, HaltCommandResponseBuilder>()
            .AddScoped<IHaltCommandResponseBuilderFactory, HaltCommandResponseBuilderFactory>()
            .AddScoped<IInitCommand, InitCommand>()
            .AddScoped<IInitCommandRequestBuilder, InitCommandRequestBuilder>()
            .AddScoped<IInitCommandRequestBuilderFactory, InitCommandRequestBuilderFactory>()
            .AddScoped<IInitCommandResponseBuilder, InitCommandResponseBuilder>()
            .AddScoped<IInitCommandResponseBuilderFactory, InitCommandResponseBuilderFactory>()
            .AddScoped<IUpCommand, UpCommand>()
            .AddScoped<IUpCommandRequestBuilder, UpCommandRequestBuilder>()
            .AddScoped<IUpCommandRequestBuilderFactory, UpCommandRequestBuilderFactory>()
            .AddScoped<IUpCommandResponseBuilder, UpCommandResponseBuilder>()
            .AddScoped<IUpCommandResponseBuilderFactory, UpCommandResponseBuilderFactory>()
            .AddScoped<ISshConfigCommand, SshConfigCommand>()
            .AddScoped<ISshConfigCommandRequestBuilder, SshConfigCommandRequestBuilder>()
            .AddScoped<ISshConfigCommandRequestBuilderFactory, SshConfigCommandRequestBuilderFactory>()
            .AddScoped<ISshConfigCommandResponseBuilder, SshConfigCommandResponseBuilder>()
            .AddScoped<ISshConfigCommandResponseBuilderFactory, SshConfigCommandResponseBuilderFactory>()
            .AddScoped<ISshCommand, SshCommand>()
            .AddScoped<ISshCommandRequestBuilderFactory, SshCommandRequestBuilderFactory>()
            .AddScoped<ISshCommandResponseBuilder, SshCommandResponseBuilder>()
            .AddScoped<ISshCommandResponseBuilderFactory, SshCommandResponseBuilderFactory>()
            .AddScoped<IStatusCommand, StatusCommand>()
            .AddScoped<IStatusCommandRequestBuilderFactory, StatusCommandRequestBuilderFactory>()
            .AddScoped<IStatusCommandResponseBuilder, StatusCommandResponseBuilder>()
            .AddScoped<IStatusCommandResponseBuilderFactory, StatusCommandResponseBuilderFactory>()
            ;

        return services;
    }
}