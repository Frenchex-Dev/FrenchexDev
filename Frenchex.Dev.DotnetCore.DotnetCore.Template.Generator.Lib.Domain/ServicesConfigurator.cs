#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services
            .AddTransient<ITemplateGenerator, TemplateGenerator>()
            .AddTransient<ITemplateInstaller, TemplateInstaller>()
            .AddTransient<ITemplateUnInstaller, TemplateUnInstaller>()
            .AddTransient<IProjectTemplateGenerator, ProjectTemplateGenerator>()
            .AddTransient<IPackagesInstaller, PackagesInstaller>();
    }
}
