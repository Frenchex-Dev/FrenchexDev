#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;

public interface ITemplateDefinition
{
    string Name { get; }
    IList<ITemplateArgumentDefinition> Args { get; }
}
