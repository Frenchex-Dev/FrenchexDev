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
using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using AddDotnetSolutionSolution = Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions.Solution;
using CsProj = Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions.CsProj;
using ITemplateGenerationResult
    = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template.ITemplateGenerationResult;
using ITemplateGenerator = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Template.ITemplateGenerator;
using TemplateGenerationErrorResult
    = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template.TemplateGenerationErrorResult;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

/// <summary>
/// </summary>
/// <param name="solutionGenerator"></param>
/// <param name="templateGenerator"></param>
/// <param name="projectGenerator"></param>
/// <param name="addProjectService"></param>
/// <param name="metaSolutionDefinitionGeneratorOptions"></param>
public class MetaSolutionDefinitionGenerator(
    ISolutionGenerator                      solutionGenerator
  , ITemplateGenerator                      templateGenerator
  , IProjectGenerator                       projectGenerator
  , IAddProjectService                      addProjectService
  , ITemplateInstaller                      templateInstaller
  , IPackagesInstaller                      packagesInstaller
  , IAddProjectReferenceService             addProjectReferenceService
  , IMetaSolutionDefinitionGeneratorOptions metaSolutionDefinitionGeneratorOptions
) : IMetaSolutionDefinitionGenerator
{
    /// <summary>
    ///     Steps :
    ///     * Generate Solution + Global
    ///     * Generate Templates in parallel
    ///     * Install Templates
    ///     * Build Project Generation Graph
    ///     * Generate Projects in parallel
    ///     * Build Solution
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
                       TemplatesGenerationsResults  = new List<ITemplateGenerationResult>()
                     , ProjectsGenerationsResults   = new List<IProjectGenerationResult>()
                     , AddProjectsToSolutionResults = new List<IAddProjectResult>()
                     , SolutionGenerationResult     = solutionGenerationErrorResult
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
                                                                                                                     = $"{metaSolutionGenerationContext.Path}\\{definition.Name}"
                                                                                                             }
                                                                                                           , token);

                                        templatesGenerationsResults.Add(templateGenerationResult);
                                    });

        if (templatesGenerationsResults.Any(x => x is TemplateGenerationErrorResult))
            return new MetaSolutionDefinitionGenerationResult
                   {
                       TemplatesGenerationsResults  = templatesGenerationsResults.ToList()
                     , ProjectsGenerationsResults   = new List<IProjectGenerationResult>()
                     , AddProjectsToSolutionResults = new List<IAddProjectResult>()
                     , SolutionGenerationResult     = solutionGenerationResult
                   };

        foreach (var templateDefinition in metaSolutionDefinition.TemplatesDefinitions)
            await templateInstaller.InstallAsync(
                                                 new CsProjPath
                                                 {
                                                     Path = $"{metaSolutionGenerationContext.Path}\\{templateDefinition.Name}"
                                                 }
                                               , cancellationToken);

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
                                                                                                                       = $"{metaSolutionGenerationContext
                                                                                                                           .Path}\\{definition.CsProj.Name}"
                                                                                                               }
                                                                                                             , token);

                                            projectsGenerationsResults.Add(projectGenerationResult);
                                        }
                                    });

        // add projects to solutions
        var addProjectToSolutionResults = new List<IAddProjectResult>();
        foreach (var projectDefinition in metaSolutionDefinition.ProjectsDefinitions)
        {
            var addProjectToSolutionResult = await addProjectService.AddAsync(
                                                                              new AddDotnetSolutionSolution
                                                                              {
                                                                                  Path
                                                                                      = $"{metaSolutionGenerationContext.Path}\\{metaSolutionDefinition.SolutionDefinition.Name}.sln"
                                                                              }
                                                                            , new CsProj
                                                                              {
                                                                                  Path
                                                                                      = $"{metaSolutionGenerationContext.Path}\\{projectDefinition.CsProj.Name}\\{projectDefinition.CsProj.Name}.csproj"
                                                                                , SolutionFolder
                                                                                      = projectDefinition.CsProj.SolutionFolder
                                                                              }
                                                                            , cancellationToken);
            addProjectToSolutionResults.Add(addProjectToSolutionResult);
        }

        return new MetaSolutionDefinitionGenerationResult
               {
                   SolutionGenerationResult     = solutionGenerationResult
                 , TemplatesGenerationsResults  = templatesGenerationsResults.ToList()
                 , ProjectsGenerationsResults   = projectsGenerationsResults.ToList()
                 , AddProjectsToSolutionResults = addProjectToSolutionResults
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
