using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<ISshCommand, SshCommand>()
            .AddScoped<ISshCommandRequestBuilderFactory, SshCommandRequestBuilderFactory>()
            .AddScoped<ISshCommandResponseBuilder, SshCommandResponseBuilder>()
            .AddScoped<ISshCommandResponseBuilderFactory, SshCommandResponseBuilderFactory>()
            ;
    }
}