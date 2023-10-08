#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class TemplateGenerationOkResult : ITemplateGenerationResult
{
    public IList<IGeneratedFile> Generation { get; } = new List<IGeneratedFile>();
}
