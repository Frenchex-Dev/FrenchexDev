#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface ITemplateArgumentDefinition
{
    string Type         { get; }
    string Name         { get; }
    string Replace      { get; }
    string DefaultValue { get; }
}
