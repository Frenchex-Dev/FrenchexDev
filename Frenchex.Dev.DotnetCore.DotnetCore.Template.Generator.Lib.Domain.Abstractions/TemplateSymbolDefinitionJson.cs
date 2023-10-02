using System.Text.Json.Serialization;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class TemplateSymbolDefinitionJson
{
    [JsonPropertyName("longName")] public string LongName { get; set; }

    [JsonPropertyName("shortName")] public string ShortName { get; set; }
}
