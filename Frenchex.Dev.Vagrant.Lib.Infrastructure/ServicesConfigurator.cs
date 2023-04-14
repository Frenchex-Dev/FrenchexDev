using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Init;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure;

/// <summary>
/// Configures your <see cref="IServiceCollection"/> so it can use this lib's external dependencies.
/// </summary>
public static class ServicesConfigurator
{
    /// <summary>
    /// Configures your <see cref="IServiceCollection"/> so it can use this lib's external dependencies
    /// </summary>
    /// <example>
    /// var servicesBuilder = new ServiceCollection();
    /// Frenchex.Dev.Vagrant.Lib.Infrastructure.ServicesConfigurator.Configure(servicesBuilder);
    /// var services = servicesBuilder.BuildServiceProvider();
    /// await using var scope = 
    /// </example>
    /// <param name="services"></param>
    public static void Configure(IServiceCollection services)
    {
        DotnetCore.Process.Lib.ServicesConfigurator.Configure(services);
    }
}