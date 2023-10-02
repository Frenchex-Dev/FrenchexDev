﻿using System.Text.Json.Serialization;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class ProjectTemplateConfigJson
{
    [JsonPropertyName("$schema")] public string Schema = "http://json.schemastore.org/template";

    [JsonPropertyName("author")] public required string Author { get; set; }

    [JsonPropertyName("classifications")] public required List<string> Classifications { get; set; }

    [JsonPropertyName("identity")] public required string Identity { get; set; }

    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("shortName")] public required string ShortName { get; set; }

    [JsonPropertyName("tags")] public required Dictionary<string, string> Tags { get; set; }

    [JsonPropertyName("symbols")] public required List<SymbolDefinitionJson> Symbols { get; set; }
}