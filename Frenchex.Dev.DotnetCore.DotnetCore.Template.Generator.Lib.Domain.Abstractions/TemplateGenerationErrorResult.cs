#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class TemplateGenerationErrorResult : ITemplateGenerationResult
{
    public IList<IGeneratedFile>   Generation { get; } = new List<IGeneratedFile>();
    public IList<IGenerationError> Errors     { get; } = new List<IGenerationError>();
}
