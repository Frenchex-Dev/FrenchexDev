#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface IProjectTemplateGenerator
{
    Task GenerateProjectTemplateAsync(
        IProjectTemplateDefinition    projectTemplateDefinition
      , IGenerationContext            generationContext
      , TemplateGenerationOkResult    okResult
      , TemplateGenerationErrorResult errorResult
      , CancellationToken             cancellationToken
    );
}
