#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using AddProjectReferenceCsProj = Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain.Abstractions.CsProj;
using IDotnetProjectSourceGenerator = Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions.IProjectGenerator;
using IProjectDefinition = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project.IProjectDefinition;
using IProjectGenerationResult = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project.IProjectGenerationResult;
using ProjectDefinition = Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions.ProjectDefinition;
using ProjectGenerationErrorResult
    = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project.ProjectGenerationErrorResult;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Project;

public class ProjectGenerator(
    IDotnetProjectSourceGenerator dotnetProjectGenerator
  , IAddPackageService            addPackageService
  , IAddProjectReferenceService   addProjectReferenceService
) : IProjectGenerator
{
    public async Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition        projectDefinition
      , IProjectGenerationContext projectGenerationContext
      , CancellationToken         cancellationToken = default
    )
    {
        var dotnetProjectGenerationResponse = await dotnetProjectGenerator.GenerateAsync(
                                                                                         new ProjectDefinition
                                                                                         {
                                                                                             Name         = projectDefinition.CsProj.Name
                                                                                           , TemplateName = projectDefinition.Template
                                                                                           , Language     = "C#"
                                                                                           , ExtraArgs
                                                                                                 = new Dictionary<string, string>(
                                                                                                                                  projectDefinition
                                                                                                                                      .TemplateArgs)
                                                                                         }
                                                                                       , new GenerationContext
                                                                                         {
                                                                                             Path = projectGenerationContext.Path
                                                                                         }
                                                                                       , cancellationToken);

        if (dotnetProjectGenerationResponse is DotnetCore.Project.Generator.Lib.Domain.Abstractions.ProjectGenerationErrorResult
            dotnetProjectGenerationError)
            return new ProjectGenerationErrorResult
                   {
                       Error   = "Error while generating project"
                     , Message = dotnetProjectGenerationError.Message
                   };

        foreach (var packageReference in projectDefinition.PackagesReferences)
        {
            var packageReferenceAddingResult = await addPackageService.AddAsync(
                                                                                new DotnetCore.Project.AddPackage.Lib.Domain.Abstractions
                                                                                .CsProj
                                                                                {
                                                                                    Path = projectGenerationContext.Path
                                                                                }
                                                                              , new PackageDefinition
                                                                                {
                                                                                    Name    = packageReference.Name
                                                                                  , Version = packageReference.Version ?? string.Empty
                                                                                }
                                                                              , cancellationToken);

            if (packageReferenceAddingResult is AddPackageErrorResult addPackageError)
                return new ProjectGenerationErrorResult
                       {
                           Error   = "Error while installing a package"
                         , Message = addPackageError.Error
                       };
        }

        foreach (var projectReference in projectDefinition.ProjectsReferences)
        {
            var projectReferenceResult = await addProjectReferenceService.AddAsync(
                                                                                   new AddProjectReferenceCsProj
                                                                                   {
                                                                                       Path = projectGenerationContext.Path
                                                                                   }
                                                                                 , new AddProjectReferenceCsProj
                                                                                   {
                                                                                       Path = projectReference.ReferencedProject.Name
                                                                                   }
                                                                                 , cancellationToken);

            if (projectReferenceResult is AddProjectReferenceErrorResult addProjectReferenceError)
                return new ProjectGenerationErrorResult
                       {
                           Error   = "Error while adding project reference"
                         , Message = addProjectReferenceError.Error
                       };
        }

        foreach (var externalProjectReference in projectDefinition.ExternalProjectsReferences)
        {
            var externalProjectReferenceAddingResult = await addProjectReferenceService.AddAsync(
                                                                                                 new AddProjectReferenceCsProj
                                                                                                 {
                                                                                                     Path = projectGenerationContext.Path
                                                                                                 }
                                                                                               , new AddProjectReferenceCsProj
                                                                                                 {
                                                                                                     Path = externalProjectReference.Path
                                                                                                 }
                                                                                               , cancellationToken);

            if (externalProjectReferenceAddingResult is AddProjectReferenceErrorResult addProjectReferenceErrorResult)
                return new ProjectGenerationErrorResult
                       {
                           Error   = "Error while adding an external project reference"
                         , Message = addProjectReferenceErrorResult.Error
                       };
        }

        return new ProjectGenerationOkResult();
    }
}
