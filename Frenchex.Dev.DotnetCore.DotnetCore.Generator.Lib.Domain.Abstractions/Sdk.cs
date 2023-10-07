#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text.Json.Serialization;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class Sdk
{
    [JsonPropertyName("version")] public required string Version { get; set; }

    [JsonPropertyName("rollForward")] public string? RollForward { get; set; }
}
