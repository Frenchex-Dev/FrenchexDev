#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib;

/// <summary>
///     Static class to configures an <see cref="IServiceCollection" /> to use this lib.
/// </summary>
public static class ServicesConfigurator
{
    /// <summary>
    ///     Static method to configures an <see cref="IServiceCollection" /> to use this lib.
    /// </summary>
    /// <param name="services"></param>
    public static void Configure(
        IServiceCollection services
    )
    {
        // scoping Domain interfaces services with Infrastructure implementations services
        services.AddTransient<IProcessStarter, ProcessStarter>()
                .AddSingleton<IProcessStarterFactory, ProcessStarterFactory>();
    }
}