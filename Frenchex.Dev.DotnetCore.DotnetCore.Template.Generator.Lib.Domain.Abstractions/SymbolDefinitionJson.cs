#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text.Json.Serialization;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class SymbolDefinitionJson
{
    [JsonPropertyName("type")] public required string Type { get; set; }

    [JsonPropertyName("defaultValue")] public required string DefaultValue { get; set; }

    [JsonPropertyName("replaces")] public required string Replaces { get; set; }
}