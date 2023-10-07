#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

/// <summary>
/// </summary>
public interface IProjectTemplateGenerator
{
    /// <summary>
    /// </summary>
    /// <param name="projectTemplateDefinition"></param>
    /// <param name="generationContext"></param>
    /// <param name="okResult"></param>
    /// <param name="errorResult"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GenerateProjectTemplateAsync(
        IProjectTemplateDefinition    projectTemplateDefinition
      , IGenerationContext            generationContext
      , TemplateGenerationOkResult    okResult
      , TemplateGenerationErrorResult errorResult
      , CancellationToken             cancellationToken
    );
}