#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib;

public static class ServicesConfigurator
{
    public static void ConfigureServices(
        IServiceCollection services
    )
    {
        Domain.ServicesConfigurator.ConfigureServices(services);
        Infrastructure.ServicesConfigurator.ConfigureServices(services);
    }
}