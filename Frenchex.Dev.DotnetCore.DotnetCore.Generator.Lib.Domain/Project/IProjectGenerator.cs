#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;
using IDotnetProjectGenerator = Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions.IProjectGenerator;
using DotnetProjectDefinition = Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions.ProjectDefinition;
using DotnetProjectGenerationContext = Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions.GenerationContext;
using DotnetProjectGenerationErrorResult = Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions.ProjectGenerationErrorResult;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Project;

public interface IProjectGenerator
{
    Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition projectDefinition
      , IProjectGenerationContext projectGenerationContext
      , CancellationToken cancellationToken = default
    );
}

public class ProjectGenerator(
    IDotnetProjectGenerator dotnetProjectGenerator
) : IProjectGenerator
{
    public async Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition        projectDefinition
      , IProjectGenerationContext projectGenerationContext
      , CancellationToken         cancellationToken = default
    )
    {
        var dotnetProjectGenerationResponse = await dotnetProjectGenerator.GenerateAsync(
                                                                                         new DotnetProjectDefinition()
                                                                                         {
                                                                                             Name         = projectDefinition.CsProj.Name
                                                                                           , TemplateName = projectDefinition.Template
                                                                                           , Language     = "C#"
                                                                                           , ExtraArgs
                                                                                                 = new Dictionary<string, string>(
                                                                                                                                  projectDefinition
                                                                                                                                      .TemplateArgs)
                                                                                         }
                                                                                       , new DotnetProjectGenerationContext()
                                                                                         {
                                                                                             Path = projectGenerationContext.Path
                                                                                         }
                                                                                       , cancellationToken);

        if (dotnetProjectGenerationResponse is DotnetProjectGenerationErrorResult dotnetProjectGenerationError)
        {
            return new IProjectGenerationErrorResult()
                   {
                       Error   = "Error while generating project"
                     , Message = dotnetProjectGenerationError.Message
                   };
        }

        // add projects references
        // add packages references
        // add external projects references

        return new ProjectGenerationOkResult();
    }
}