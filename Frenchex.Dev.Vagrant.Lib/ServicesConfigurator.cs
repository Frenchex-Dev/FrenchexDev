#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Init;
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
    public static void Configure(IServiceCollection services)
    {
        Infrastructure.ServicesConfigurator.Configure(services);
        Domain.ServicesConfigurator.Configure(services);

        // scoping Domain interfaces services with Infrastructure implementations services
        services.AddScoped<IVagrantInitCommand, VagrantInitCommand>();
    }
}
