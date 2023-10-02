using System.Text.Json.Serialization;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class SymbolDefinitionJson
{
    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("defaultValue")] public string DefaultValue { get; set; }

    [JsonPropertyName("replaces")] public string Replaces { get; set; }
}
