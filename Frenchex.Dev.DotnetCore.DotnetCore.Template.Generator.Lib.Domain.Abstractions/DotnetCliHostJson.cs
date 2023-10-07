#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text.Json.Serialization;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class DotnetCliHostJson
{
    [JsonPropertyName("symbolInfo")] public required List<TemplateSymbolDefinitionJson> SymbolInfo { get; set; }
}