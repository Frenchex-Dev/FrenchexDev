#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        ConfigureCommandLineBuilders(services);
        ConfigureCommands(services);
        ConfigureRequestBuilders(services);
        ConfigureResponseBuilders(services);
    }

    public static void ConfigureResponseBuilders(
        IServiceCollection services
    )
    {
        services
            .AddTransient<IVagrantDestroyResponseBuilder, VagrantDestroyResponseBuilder>()
            .AddTransient<IVagrantHaltResponseBuilder, VagrantHaltResponseBuilder>()
            .AddTransient<IVagrantInitResponseBuilder, VagrantInitResponseBuilder>()
            .AddTransient<IVagrantProvisionResponseBuilder, VagrantProvisionResponseBuilder>()
            .AddTransient<IVagrantSshResponseBuilder, VagrantSshResponseBuilder>()
            .AddTransient<IVagrantSshConfigResponseBuilder, VagrantSshConfigResponseBuilder>()
            .AddTransient<IVagrantStatusResponseBuilder, VagrantStatusResponseBuilder>()
            .AddTransient<IVagrantUpResponseBuilder, VagrantUpResponseBuilder>();
    }

    public static void ConfigureRequestBuilders(
        IServiceCollection services
    )
    {
        services
            .AddTransient<IVagrantDestroyRequestBuilder, VagrantDestroyRequestBuilder>()
            .AddTransient<IVagrantHaltRequestBuilder, VagrantHaltRequestBuilder>()
            .AddTransient<IVagrantInitRequestBuilder, VagrantInitRequestBuilder>()
            .AddTransient<IVagrantProvisionRequestBuilder, VagrantProvisionRequestBuilder>()
            .AddTransient<IVagrantSshRequestBuilder, VagrantSshRequestBuilder>()
            .AddTransient<IVagrantSshConfigRequestBuilder, VagrantSshConfigRequestBuilder>()
            .AddTransient<IVagrantStatusRequestBuilder, VagrantStatusRequestBuilder>()
            .AddTransient<IVagrantUpRequestBuilder, VagrantUpRequestBuilder>();
    }

    public static void ConfigureCommands(
        IServiceCollection services
    )
    {
        services.AddTransient<IVagrantCommandsFacade, VagrantCommandsFacade>();

        services
            .AddTransient<IVagrantDestroyCommand, VagrantDestroyCommand>()
            .AddTransient<IVagrantHaltCommand, VagrantHaltCommand>()
            .AddTransient<IVagrantInitCommand, VagrantInitCommand>()
            .AddTransient<IVagrantProvisionCommand, VagrantProvisionCommand>()
            .AddTransient<IVagrantSshCommand, VagrantSshCommand>()
            .AddTransient<IVagrantSshConfigCommand, VagrantSshConfigCommand>()
            .AddTransient<IVagrantStatusCommand, VagrantStatusCommand>()
            .AddTransient<IVagrantUpCommand, VagrantUpCommand>();
    }

    public static void ConfigureCommandLineBuilders(
        IServiceCollection services
    )
    {
        services
            .AddTransient<IVagrantDestroyCommandLineBuilder, VagrantDestroyCommandLineBuilder>()
            .AddTransient<IVagrantHaltCommandLineBuilder, VagrantHaltCommandLineBuilder>()
            .AddTransient<IVagrantInitCommandLineBuilder, VagrantInitCommandLineBuilder>()
            .AddTransient<IVagrantProvisionCommandLineBuilder, VagrantProvisionCommandLineBuilder>()
            .AddTransient<IVagrantSshCommandLineBuilder, VagrantSshCommandLineBuilder>()
            .AddTransient<IVagrantSshConfigCommandLineBuilder, VagrantSshConfigCommandLineBuilder>()
            .AddTransient<IVagrantStatusCommandLineBuilder, VagrantStatusCommandLineBuilder>()
            .AddTransient<IVagrantUpCommandLineBuilder, VagrantUpCommandLineBuilder>();
    }
}
