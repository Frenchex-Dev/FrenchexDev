#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;
using Frenchex.Dev.Vos.Cli.IntegrationLib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        return StaticConfigureServices(serviceCollection);
    }

    /// <summary>
    ///     Configure services object against integration classes.
    ///     Integration classes are meant to be used only once during execution of CLI.
    ///     Marking them as Singleton will save their unique instance into the DI.
    ///     While we only need them once.
    ///     So we mark them as Transient so that created instances will not be managed
    ///     by DI.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection StaticConfigureServices(IServiceCollection services)
    {
        return new ServicesConfigurationServices().ConfigureServices(services,
            () =>
            {
                services.AddScoped<IIntegration, Domain.Integration>();

                DependencyInjectionConfigurator.ConfigureServices(services);
                Domain.Arguments.DependencyInjectionConfigurator.ConfigureServices(services);
                Domain.Options.DependencyInjectionConfigurator.ConfigureServices(services);
            },
            () => { Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services); });
    }
}