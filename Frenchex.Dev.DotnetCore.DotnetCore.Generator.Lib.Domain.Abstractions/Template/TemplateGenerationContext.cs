#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;

public class TemplateGenerationContext : ITemplateGenerationContext
{
    public required string Path { get; set; }
}
