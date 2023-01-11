#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddLogging();

        serviceCollection
            .AddScoped<IProcessBuilder, AsyncProcessBuilder>()
            ;

        ConfigureDependencies(serviceCollection);
    }

    private static void ConfigureDependencies(IServiceCollection serviceCollection)
    {
        Tooling.TimeSpan.Lib.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
    }
}