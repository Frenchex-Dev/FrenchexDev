#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface ITemplateDefinition
{
    string                      Name            { get; }
    string                      Author          { get; }
    IList<string>               Classifications { get; }
    string                      Identity        { get; }
    string                      ShortName       { get; }
    IDictionary<string, string> Tags            { get; }
    IList<ISymbolDefinition>    Symbols         { get; }
}