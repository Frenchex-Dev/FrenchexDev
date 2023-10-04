#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib;

/// <summary>
///     Configures your <see cref="IServiceCollection" /> so it can uses this lib.
/// </summary>
public static class ServicesConfigurator
{
    /// <summary>
    ///     Configures your <see cref="IServiceCollection" /> so it can uses this lib.
    /// </summary>
    /// <param name="services"></param>
    public static void Configure(
        IServiceCollection services
    )
    {
        Infrastructure.ServicesConfigurator.Configure(services);
        Domain.ServicesConfigurator.Configure(services);

        services.AddScoped<IVagrantDestroyCommand, VagrantDestroyCommand>()
                .AddScoped<IVagrantHaltCommand, VagrantHaltCommand>()
                .AddScoped<IVagrantInitCommand, VagrantInitCommand>()
                .AddScoped<IVagrantProvisionCommand, VagrantProvisionCommand>()
                .AddScoped<IVagrantSshCommand, VagrantSshCommand>()
                .AddScoped<IVagrantSshConfigCommand, VagrantSshConfigCommand>()
                .AddScoped<IVagrantStatusCommand, VagrantStatusCommand>()
                .AddScoped<IVagrantUpCommand, VagrantUpCommand>();
    }
}
