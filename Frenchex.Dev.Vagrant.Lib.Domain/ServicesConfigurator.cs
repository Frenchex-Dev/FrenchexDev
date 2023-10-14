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
        services
            .AddTransient<IVagrantDestroyCommand, VagrantDestroyCommand>()
            .AddTransient<IVagrantDestroyCommandLineBuilder, VagrantDestroyCommandLineBuilder>()
            .AddTransient<IVagrantDestroyRequestBuilder, VagrantDestroyRequestBuilder>()
            .AddTransient<IVagrantHaltCommand, VagrantHaltCommand>()
            .AddTransient<IVagrantHaltCommandLineBuilder, VagrantHaltCommandLineBuilder>()
            .AddTransient<IVagrantHaltRequestBuilder, VagrantHaltRequestBuilder>()
            .AddTransient<IVagrantInitCommand, VagrantInitCommand>()
            .AddTransient<IVagrantInitCommandLineBuilder, VagrantInitCommandLineBuilder>()
            .AddTransient<IVagrantInitRequestBuilder, VagrantInitRequestBuilder>()
            .AddTransient<IVagrantProvisionCommand, VagrantProvisionCommand>()
            .AddTransient<IVagrantProvisionCommandLineBuilder, VagrantProvisionCommandLineBuilder>()
            .AddTransient<IVagrantProvisionRequestBuilder, VagrantProvisionRequestBuilder>()
            .AddTransient<IVagrantSshCommand, VagrantSshCommand>()
            .AddTransient<IVagrantSshCommandLineBuilder, VagrantSshCommandLineBuilder>()
            .AddTransient<IVagrantSshRequestBuilder, VagrantSshRequestBuilder>()
            .AddTransient<IVagrantSshConfigCommand, VagrantSshConfigCommand>()
            .AddTransient<IVagrantSshConfigCommandLineBuilder, VagrantSshConfigCommandLineBuilder>()
            .AddTransient<IVagrantSshConfigRequestBuilder, VagrantSshConfigRequestBuilder>()
            .AddTransient<IVagrantStatusCommand, VagrantStatusCommand>()
            .AddTransient<IVagrantStatusCommandLineBuilder, VagrantStatusCommandLineBuilder>()
            .AddTransient<IVagrantStatusRequestBuilder, VagrantStatusRequestBuilder>()
            .AddTransient<IVagrantUpCommand, VagrantUpCommand>()
            .AddTransient<IVagrantUpCommandLineBuilder, VagrantUpCommandLineBuilder>()
            .AddTransient<IVagrantUpRequestBuilder, VagrantUpRequestBuilder>();
    }
}
