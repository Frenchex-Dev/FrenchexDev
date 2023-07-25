#region Usings

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
    public static void Configure(IServiceCollection services)
    {
        services.AddScoped<IVagrantDestroyCommandLineBuilder, VagrantDestroyCommandLineBuilder>()
                .AddScoped<IVagrantHaltCommandLineBuilder, VagrantHaltCommandLineBuilder>()
                .AddScoped<IVagrantInitCommandLineBuilder, VagrantInitCommandLineBuilder>()
                .AddScoped<IVagrantProvisionCommandLineBuilder, VagrantProvisionCommandLineBuilder>()
                .AddScoped<IVagrantSshCommandLineBuilder, VagrantSshCommandLineBuilder>()
                .AddScoped<IVagrantSshConfigCommandLineBuilder, VagrantSshConfigCommandLineBuilder>()
                .AddScoped<IVagrantStatusCommandLineBuilder, VagrantStatusCommandLineBuilder>()
                .AddScoped<IVagrantUpCommandLineBuilder, VagrantUpCommandLineBuilder>();
    }
}
