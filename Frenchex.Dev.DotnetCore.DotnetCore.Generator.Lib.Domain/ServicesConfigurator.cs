#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public static class ServicesConfigurator
{
    public static void ConfigureServices(
        IServiceCollection services
    )
    {
        services
            .AddTransient<IMetaSolutionDefinitionGenerator, MetaSolutionDefinitionGenerator>()
            .AddTransient<ISolutionGenerator, SolutionGenerator>()
            .AddTransient<ITemplateGenerator, TemplateGenerator>()
            .AddTransient<IProjectGenerator, ProjectGenerator>();
    }
}
