#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services.AddTransient<IAddPackageService, AddPackageService>();
    }
}
