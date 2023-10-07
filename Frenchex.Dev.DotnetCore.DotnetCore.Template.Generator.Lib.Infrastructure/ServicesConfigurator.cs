#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

/// <summary>
/// </summary>
public static class ServicesConfigurator
{
    /// <summary>
    /// </summary>
    /// <param name="services"></param>
    public static void Configure(
        IServiceCollection services
    )
    {
        Process.Lib.ServicesConfigurator.Configure(services);

        services.AddTransient<IPackagesInstaller, PackagesInstaller>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<IPackagesInstaller, PackagesInstaller>()
                .AddTransient<IGeneratedCodeWriter, GeneratedCodeWriter>()
                .AddTransient<ITemplateInstaller, TemplateInstaller>()
                .AddTransient<ITemplateUnInstaller, TemplateUnInstaller>();
    }
}