#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.DependencyInjection;

public static class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        ConfigureDependencies(serviceCollection);
    }

    private static void ConfigureDependencies(IServiceCollection serviceCollection)
    {
        Abstractions.DependencyInjection.DependencyInjection.ConfigureServices(serviceCollection);
    }
}