#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Collections.Concurrent;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Template;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

/// <summary>
/// </summary>
/// <param name="solutionGenerator"></param>
/// <param name="templateGenerator"></param>
/// <param name="projectGenerator"></param>
public class MetaSolutionDefinitionGenerator(
    ISolutionGenerator solutionGenerator
  , ITemplateGenerator templateGenerator
  , IProjectGenerator  projectGenerator
  , IMetaSolutionDefinitionGeneratorOptions metaSolutionDefinitionGeneratorOptions
) : IMetaSolutionDefinitionGenerator
{
    /// <summary>
    /// </summary>
    /// <param name="metaSolutionDefinition"></param>
    /// <param name="metaSolutionGenerationContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IMetaSolutionDefinitionGenerationResult> GenerateAsync(
        IMetaSolutionDefinition        metaSolutionDefinition
      , IMetaSolutionGenerationContext metaSolutionGenerationContext
      , CancellationToken              cancellationToken = default
    )
    {
        var solutionGenerationResult = await solutionGenerator.GenerateAsync(
                                                                             metaSolutionDefinition.SolutionDefinition
                                                                           , new SolutionGenerationContext
                                                                             {
                                                                                 Path = metaSolutionGenerationContext.Path
                                                                             }
                                                                           , cancellationToken);

        if (solutionGenerationResult is SolutionGenerationErrorResult solutionGenerationErrorResult)
            return new MetaSolutionDefinitionGenerationResult
                   {
                       TemplatesGenerationsResults = new List<ITemplateGenerationResult>()
                     , ProjectsGenerationsResults  = new List<IProjectGenerationResult>()
                     , SolutionGenerationResult    = solutionGenerationErrorResult
                   };

        var templatesGenerationsResults = new ConcurrentBag<ITemplateGenerationResult>();

        await Parallel.ForEachAsync(
                                    metaSolutionDefinition.TemplatesDefinitions
                                  , new ParallelOptions
                                    {
                                        MaxDegreeOfParallelism = metaSolutionDefinitionGeneratorOptions.TemplatesGenerationMaxConcurrency
                                      , CancellationToken      = cancellationToken
                                    }
                                  , async (
                                        definition
                                      , token
                                    ) =>
                                    {
                                        var templateGenerationResult = await templateGenerator.GenerateAsync(
                                                                                                             definition
                                                                                                           , new
                                                                                                             TemplateGenerationContext
                                                                                                             {
                                                                                                                 Path
                                                                                                                     = metaSolutionGenerationContext
                                                                                                                         .Path
                                                                                                             }
                                                                                                           , token);

                                        templatesGenerationsResults.Add(templateGenerationResult);
                                    });

        if (templatesGenerationsResults.Any(x => x is TemplateGenerationErrorResult))
            return new MetaSolutionDefinitionGenerationResult
                   {
                       TemplatesGenerationsResults = templatesGenerationsResults.ToList()
                     , ProjectsGenerationsResults  = new List<IProjectGenerationResult>()
                     , SolutionGenerationResult    = solutionGenerationResult
                   };

        var graphOfBuildGenerationOrder = await BuildGraphOfGenerationOrder(metaSolutionDefinition.ProjectsDefinitions);

        var projectsGenerationsResults = new ConcurrentBag<IProjectGenerationResult>();

        await Parallel.ForEachAsync(
                                    graphOfBuildGenerationOrder
                                  , new ParallelOptions
                                    {
                                        MaxDegreeOfParallelism = metaSolutionDefinitionGeneratorOptions.ProjectsGenerationMaxConcurrency
                                      , CancellationToken      = cancellationToken
                                    }
                                  , async (
                                        definitions
                                      , token
                                    ) =>
                                    {
                                        foreach (var definition in definitions)
                                        {
                                            var projectGenerationResult = await projectGenerator.GenerateAsync(
                                                                                                               definition
                                                                                                             , new
                                                                                                               ProjectGenerationContext
                                                                                                               {
                                                                                                                   Path
                                                                                                                       = metaSolutionGenerationContext
                                                                                                                           .Path
                                                                                                               }
                                                                                                             , token);

                                            projectsGenerationsResults.Add(projectGenerationResult);
                                        }
                                    });

        return new MetaSolutionDefinitionGenerationResult
               {
                   SolutionGenerationResult    = solutionGenerationResult
                 , TemplatesGenerationsResults = templatesGenerationsResults.ToList()
                 , ProjectsGenerationsResults  = projectsGenerationsResults.ToList()
               };
    }

    private static Task<IList<IList<IProjectDefinition>>> BuildGraphOfGenerationOrder(
        IList<IProjectDefinition> projectsDefinitions
    )
    {
        return Task.FromResult<IList<IList<IProjectDefinition>>>(
                                                                 new List<IList<IProjectDefinition>>
                                                                 {
                                                                     projectsDefinitions
                                                                 });
    }
}
