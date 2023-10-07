#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;

public class TemplateArgumentDefinition : ITemplateArgumentDefinition
{
    public required string Type { get; set; }
    public required string Name { get; set; }
    public required string Replace { get; set; }
    public required string DefaultValue { get; set; }
}
