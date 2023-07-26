#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure;

/// <summary>
///     Configures your <see cref="IServiceCollection" /> so it can use this lib's external dependencies.
/// </summary>
public static class ServicesConfigurator
{
    /// <summary>
    ///     Configures your <see cref="IServiceCollection" /> so it can use this lib's external dependencies
    /// </summary>
    /// <example>
    ///     var servicesBuilder = new ServiceCollection();
    ///     Frenchex.Dev.Vagrant.Lib.Infrastructure.ServicesConfigurator.Configure(servicesBuilder);
    ///     var services = servicesBuilder.BuildServiceProvider();
    ///     await using var scope =
    /// </example>
    /// <param name="services"></param>
    public static void Configure(
        IServiceCollection services
    )
    {
        DotnetCore.Process.Lib.ServicesConfigurator.Configure(services);
    }
}
