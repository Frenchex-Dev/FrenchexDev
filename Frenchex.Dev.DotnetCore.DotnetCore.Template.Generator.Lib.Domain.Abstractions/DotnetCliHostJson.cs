using System.Text.Json.Serialization;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class DotnetCliHostJson
{
    [JsonPropertyName("symbolInfo")] public required List<TemplateSymbolDefinitionJson> SymbolInfo { get; set; }
}