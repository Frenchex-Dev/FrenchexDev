#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;
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
                .AddScoped<IVagrantDestroyCommandLineBuilder, VagrantDestroyCommandLineBuilder>()
                .AddScoped<IVagrantDestroyRequestBuilder, VagrantDestroyRequestBuilder>()
                .AddScoped<IVagrantHaltCommand, VagrantHaltCommand>()
                .AddScoped<IVagrantHaltCommandLineBuilder, VagrantHaltCommandLineBuilder>()
                .AddScoped<IVagrantHaltRequestBuilder, VagrantHaltRequestBuilder>()
                .AddScoped<IVagrantInitCommand, VagrantInitCommand>()
                .AddScoped<IVagrantInitCommandLineBuilder, VagrantInitCommandLineBuilder>()
                .AddScoped<IVagrantInitRequestBuilder, VagrantInitRequestBuilder>()
                .AddScoped<IVagrantProvisionCommand, VagrantProvisionCommand>()
                .AddScoped<IVagrantProvisionCommandLineBuilder, VagrantProvisionCommandLineBuilder>()
                .AddScoped<IVagrantProvisionRequestBuilder, VagrantProvisionRequestBuilder>()
                .AddScoped<IVagrantSshCommand, VagrantSshCommand>()
                .AddScoped<IVagrantSshCommandLineBuilder, VagrantSshCommandLineBuilder>()
                .AddScoped<IVagrantSshRequestBuilder, VagrantSshRequestBuilder>()
                .AddScoped<IVagrantSshConfigCommand, VagrantSshConfigCommand>()
                .AddScoped<IVagrantSshConfigCommandLineBuilder, VagrantSshConfigCommandLineBuilder>()
                .AddScoped<IVagrantSshConfigRequestBuilder, VagrantSshConfigRequestBuilder>()
                .AddScoped<IVagrantStatusCommand, VagrantStatusCommand>()
                .AddScoped<IVagrantStatusCommandLineBuilder, VagrantStatusCommandLineBuilder>()
                .AddScoped<IVagrantStatusRequestBuilder, VagrantStatusRequestBuilder>()
                .AddScoped<IVagrantUpCommand, VagrantUpCommand>()
                .AddScoped<IVagrantUpCommandLineBuilder, VagrantUpCommandLineBuilder>()
                .AddScoped<IVagrantUpRequestBuilder, VagrantUpRequestBuilder>();
    }
}
