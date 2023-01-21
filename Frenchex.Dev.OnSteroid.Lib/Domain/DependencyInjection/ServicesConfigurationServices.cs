#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;

public class ServicesConfigurationServices : IServicesConfigurationServices, IDiscoverableServicesConfiguration
{
    public IServiceCollection ConfigureServices(
        IServiceCollection services,
        Action servicesConfiguration,
        Action dependenciesServicesConfiguration
    )
    {
        servicesConfiguration.Invoke();
        dependenciesServicesConfiguration.Invoke();

        return services;
    }
}