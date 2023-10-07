#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib;

/// <summary>
///     Configures your <see cref="IServiceCollection" /> so it can uses this lib.
/// </summary>
public static class ServicesConfigurator
{
    /// <summary>
    ///     Configures your <see cref="IServiceCollection" /> so it can uses this lib.
    /// </summary>
    /// <param name="services"></param>
    public static void Configure(
        IServiceCollection services
    )
    {
        Infrastructure.ServicesConfigurator.Configure(services);
        Domain.ServicesConfigurator.Configure(services);
    }
}