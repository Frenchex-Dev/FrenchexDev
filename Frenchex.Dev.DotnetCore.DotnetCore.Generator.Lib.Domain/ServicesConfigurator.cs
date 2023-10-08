#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Template;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services
            .AddTransient<IMetaSolutionDefinitionGenerator, MetaSolutionDefinitionGenerator>()
            .AddTransient<IMetaSolutionDefinitionGeneratorOptions>( //@todo make it using IOptions pattern
                                                                   _ => new MetaSolutionDefinitionGeneratorOptions
                                                                        {
                                                                            ProjectsGenerationMaxConcurrency  = 100
                                                                          , TemplatesGenerationMaxConcurrency = 100
                                                                        })
            .AddTransient<ISolutionGenerator, SolutionGenerator>()
            .AddTransient<IGlobalGenerator, GlobalGenerator>()
            .AddTransient<ITemplateGenerator, TemplateGenerator>()
            .AddTransient<IProjectGenerator, ProjectGenerator>();
    }
}
