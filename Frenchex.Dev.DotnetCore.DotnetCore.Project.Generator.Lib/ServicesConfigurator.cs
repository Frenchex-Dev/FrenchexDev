#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        Domain.ServicesConfigurator.Configure(services);
        Infrastructure.ServicesConfigurator.Configure(services);
    }
}