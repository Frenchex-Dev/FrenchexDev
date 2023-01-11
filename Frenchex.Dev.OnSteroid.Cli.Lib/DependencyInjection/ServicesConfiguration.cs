#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;
using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Cli.Lib.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        return StaticConfigureServices(serviceCollection);
    }

    public static IServiceCollection StaticConfigureServices(IServiceCollection services)
    {
        return new ServicesConfigurationServices().ConfigureServices(services,
            () =>
            {
                services
                    .AddScoped<IProgramBuilder, ProgramBuilder>()
                    ;
            },
            () =>
            {
                OnSteroid.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
                Dotnet.Core.Cli.Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
            });
    }
}