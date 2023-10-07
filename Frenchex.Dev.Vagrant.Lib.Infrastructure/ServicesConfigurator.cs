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

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure;

/// <summary>
///     Configures your <see cref="IServiceCollection" /> so it can use this lib's external dependencies.
/// </summary>
public static class ServicesConfigurator
{
    /// <summary>
    ///     Configures your <see cref="IServiceCollection" /> so it can use this lib's external dependencies
    /// </summary>
    /// <example>
    ///     var servicesBuilder = new ServiceCollection();
    ///     Frenchex.Dev.Vagrant.Lib.Infrastructure.ServicesConfigurator.Configure(servicesBuilder);
    ///     var services = servicesBuilder.BuildServiceProvider();
    ///     await using var scope =
    /// </example>
    /// <param name="services"></param>
    public static void Configure(
        IServiceCollection services
    )
    {
        DotnetCore.Process.Lib.ServicesConfigurator.Configure(services);

        services.AddTransient<IVagrantDestroyCommand, VagrantDestroyCommand>()
                .AddTransient<IVagrantHaltCommand, VagrantHaltCommand>()
                .AddTransient<IVagrantInitCommand, VagrantInitCommand>()
                .AddTransient<IVagrantProvisionCommand, VagrantProvisionCommand>()
                .AddTransient<IVagrantSshCommand, VagrantSshCommand>()
                .AddTransient<IVagrantSshConfigCommand, VagrantSshConfigCommand>()
                .AddTransient<IVagrantStatusCommand, VagrantStatusCommand>()
                .AddTransient<IVagrantUpCommand, VagrantUpCommand>();
    }
}