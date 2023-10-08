#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using IDotnetProjectSourceGenerator = Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions.IProjectGenerator;
using IProjectDefinition = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project.IProjectDefinition;
using IProjectGenerationResult = Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project.IProjectGenerationResult;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Project;

public class ProjectGenerator(
    IDotnetProjectSourceGenerator dotnetProjectGenerator
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

        if (dotnetProjectGenerationResponse is ProjectGenerationErrorResult dotnetProjectGenerationError)
            return new IProjectGenerationErrorResult
                   {
                       Error   = "Error while generating project"
                     , Message = dotnetProjectGenerationError.Message
                   };

        // add projects references
        // add packages references
        // add external projects references

        return new ProjectGenerationOkResult();
    }
}
