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
                .AddScoped<IVagrantDestroyRequestBuilder, VagrantDestroyRequestBuilder>()
                .AddScoped<IVagrantHaltCommandLineBuilder, VagrantHaltCommandLineBuilder>()
                .AddScoped<IVagrantHaltRequestBuilder, VagrantHaltRequestBuilder>()
                .AddScoped<IVagrantInitCommandLineBuilder, VagrantInitCommandLineBuilder>()
                .AddScoped<IVagrantInitRequestBuilder, VagrantInitRequestBuilder>()
                .AddScoped<IVagrantProvisionCommandLineBuilder, VagrantProvisionCommandLineBuilder>()
                .AddScoped<IVagrantProvisionRequestBuilder, VagrantProvisionRequestBuilder>()
                .AddScoped<IVagrantSshCommandLineBuilder, VagrantSshCommandLineBuilder>()
                .AddScoped<IVagrantSshRequestBuilder, VagrantSshRequestBuilder>()
                .AddScoped<IVagrantSshConfigCommandLineBuilder, VagrantSshConfigCommandLineBuilder>()
                .AddScoped<IVagrantSshConfigRequestBuilder, VagrantSshConfigRequestBuilder>()
                .AddScoped<IVagrantStatusCommandLineBuilder, VagrantStatusCommandLineBuilder>()
                .AddScoped<IVagrantStatusRequestBuilder, VagrantStatusRequestBuilder>()
                .AddScoped<IVagrantUpCommandLineBuilder, VagrantUpCommandLineBuilder>()
                .AddScoped<IVagrantUpRequestBuilder, VagrantUpRequestBuilder>();
    }
}
