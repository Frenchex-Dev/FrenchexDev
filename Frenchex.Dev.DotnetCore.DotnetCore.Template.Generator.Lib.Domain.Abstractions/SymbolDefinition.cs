#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class SymbolDefinition : ISymbolDefinition
{
    public required string Type { get; set; }

    public required string DefaultValue { get; set; }

    public required string Replaces { get; set; }

    public required string Name      { get; set; }
    public required string ShortName { get; set; }
    public required string LongName  { get; set; }
}