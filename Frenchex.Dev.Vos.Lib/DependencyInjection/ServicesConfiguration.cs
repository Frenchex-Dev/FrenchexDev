using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.DependencyInjection;
using Frenchex.Dev.Vos.Lib.Domain.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        return StaticConfigureServices(serviceCollection);
    }

    public static IServiceCollection StaticConfigureServices(IServiceCollection serviceCollection)
    {
        return new ServicesConfigurationServices()
            .ConfigureServices(serviceCollection,
                () =>
                {
                    // resources
                    serviceCollection
                        .AddScoped<IVagrantfileResource, VagrantfileResource>()
                        ;

                    Abstractions.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);

                    ServicesConfguration.ConfigureServices(serviceCollection);

                    Domain.Actions.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.Define.Machine.Add.DependecyInjection.ServicesConfiguration
                        .ConfigureServices(serviceCollection);

                    Domain.Commands.Define.MachineType.Add.DependecyInjection.ServicesConfiguration
                        .ConfigureServices(serviceCollection);

                    Domain.Commands.Define.Provisioning.Map.DependencyInjection.ServicesConfiguration
                        .ConfigureServices(serviceCollection);

                    Domain.Commands.Destroy.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.Halt.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.Init.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.Name.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.Ssh.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.SshConfig.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.Status.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);

                    Domain.Commands.Up.DependencyInjection.ServicesConfiguration.ConfigureServices(
                        serviceCollection);
                },
                () =>
                {
                    // dependencies
                    Dotnet.Core.Filesystem.Lib.DependencyInjection.ServicesConfiguration
                        .ConfigureServices(serviceCollection)
                        ;

                    Vagrant.Lib.DependencyInjection.ServicesConfiguration
                        .ConfigureServices(serviceCollection)
                        ;

                    OnSteroid.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(serviceCollection);
                });
    }
}