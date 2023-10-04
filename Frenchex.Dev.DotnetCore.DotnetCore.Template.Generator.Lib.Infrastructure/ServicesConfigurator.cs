#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services.AddTransient<IPackagesInstaller, PackagesInstaller>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<IPackagesInstaller, PackagesInstaller>()
                .AddTransient<IGeneratedCodeWriter, GeneratedCodeWriter>()
                .AddTransient<ITemplateInstaller, TemplateInstaller>()
                .AddTransient<ITemplateUnInstaller, TemplateUnInstaller>();
    }
}
