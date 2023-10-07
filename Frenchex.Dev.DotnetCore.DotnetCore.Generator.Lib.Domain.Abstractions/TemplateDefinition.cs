#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class TemplateDefinition : ITemplateDefinition
{
    public required string                             Name { get; set; }
    public required IList<ITemplateArgumentDefinition> Args { get; set; }
}
