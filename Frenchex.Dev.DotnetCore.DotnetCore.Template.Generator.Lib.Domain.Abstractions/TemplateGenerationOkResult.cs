#region Licensing

// Licensing please read LICENSE.md

#endregion

using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class TemplateGenerationOkResult : ITemplateGenerationResult
{
    public IList<IGeneratedFile> Generation { get; } = new List<IGeneratedFile>();
}
