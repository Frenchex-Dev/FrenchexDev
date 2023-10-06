#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Collections.Concurrent;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using IGenerationContext = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.IGenerationContext;
using TemplateGenerationContext = Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions.GenerationContext;
using SolutionGenerationContext = Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions.GenerationContext;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain
{
    public class MetaSolutionDefinitionGenerator(
        ISolutionGenerator solutionGenerator
      , ITemplateGenerator templateGenerator
      , IProjectGenerator  projectGenerator
    ) : IMetaSolutionDefinitionGenerator
    {
        public async Task<IMetaSolutionDefinitionGenerationResult> GenerateAsync(
            IMetaSolutionDefinition metaSolutionDefinition
          , IGenerationContext      generationContext
          , CancellationToken       cancellationToken = default
        )
        {
            var solutionGenerationResult = await solutionGenerator.GenerateAsync(
                                                                                 metaSolutionDefinition.SolutionDefinition
                                                                               , new SolutionGenerationContext
                                                                                 {
                                                                                     Path = generationContext.Path
                                                                                 }
                                                                               , cancellationToken);

            if (solutionGenerationResult is SolutionGenerationErrorResult solutionGenerationErrorResult)
            {
                return new MetaSolutionDefinitionGenerationResult
                       {
                           TemplatesGenerationsResults = new List<ITemplateGenerationResult>()
                         , ProjectsGenerationsResults  = new List<IProjectGenerationResult>()
                         , SolutionGenerationResult    = solutionGenerationErrorResult
                       };
            }

            var templatesGenerationsResults = new ConcurrentBag<ITemplateGenerationResult>();

            await Parallel.ForEachAsync(
                                        metaSolutionDefinition.TemplatesDefinitions
                                      , new ParallelOptions
                                        {
                                            MaxDegreeOfParallelism = 100
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
                                                                                                                         = generationContext
                                                                                                                             .Path
                                                                                                                 }
                                                                                                               , token);

                                            templatesGenerationsResults.Add(templateGenerationResult);
                                        });

            if (templatesGenerationsResults.Any(x => x is TemplateGenerationErrorResult))
            {
                return new MetaSolutionDefinitionGenerationResult
                       {
                           TemplatesGenerationsResults = templatesGenerationsResults.ToList()
                         , ProjectsGenerationsResults  = new List<IProjectGenerationResult>()
                         , SolutionGenerationResult    = solutionGenerationResult
                       };
            }

            var graphOfBuildGenerationOrder = await BuildGraphOfGenerationOrder(metaSolutionDefinition.ProjectsDefinitions);

            var projectsGenerationsResults = new ConcurrentBag<IProjectGenerationResult>();

            await Parallel.ForEachAsync(
                                        graphOfBuildGenerationOrder
                                      , new ParallelOptions
                                        {
                                            MaxDegreeOfParallelism = 100
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
                                                                                                                 , new Project.Generator.
                                                                                                                   Lib.Domain.
                                                                                                                   Abstractions.
                                                                                                                   GenerationContext
                                                                                                                   {
                                                                                                                       Path
                                                                                                                           = generationContext
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
}
