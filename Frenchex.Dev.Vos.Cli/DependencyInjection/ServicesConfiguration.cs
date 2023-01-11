#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Cli.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration, IDiscoverableServicesConfiguration
{
    private readonly IServicesConfigurationServicesFactory _servicesConfigurationServicesFactory;

    public ServicesConfiguration(
        IServicesConfigurationServicesFactory servicesConfigurationServicesFactory
    )
    {
        _servicesConfigurationServicesFactory = servicesConfigurationServicesFactory;
    }

    public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        return StaticConfigureServices(serviceCollection, _servicesConfigurationServicesFactory.Factory());
    }

    public static IServiceCollection StaticConfigureServices(
        IServiceCollection services,
        IServicesConfigurationServices servicesConfigurationServices
    )
    {
        return servicesConfigurationServices
            .ConfigureServices(services,
                () => { services.AddHostedService<Host>(); },
                () =>
                {
                    Integration.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                    Dotnet.Core.Cli.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                    OnSteroid.Cli.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                });
    }
}