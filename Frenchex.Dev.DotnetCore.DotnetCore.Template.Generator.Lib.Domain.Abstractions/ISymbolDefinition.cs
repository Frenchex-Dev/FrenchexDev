#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface ISymbolDefinition
{
    string Type         { get; }
    string DefaultValue { get; }
    string Replaces     { get; }
    string Name         { get; }
    string ShortName    { get; }
    string LongName     { get; set; }
}