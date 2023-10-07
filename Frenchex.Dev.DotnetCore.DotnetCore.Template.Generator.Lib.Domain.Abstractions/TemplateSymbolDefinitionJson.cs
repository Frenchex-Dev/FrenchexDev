#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text.Json.Serialization;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class TemplateSymbolDefinitionJson
{
    [JsonPropertyName("longName")] public required string LongName { get; set; }

    [JsonPropertyName("shortName")] public required string ShortName { get; set; }
}