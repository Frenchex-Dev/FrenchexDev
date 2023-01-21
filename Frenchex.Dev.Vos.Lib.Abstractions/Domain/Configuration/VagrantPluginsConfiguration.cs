#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Newtonsoft.Json;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Configuration;

public class VagrantPluginsConfiguration
{
    [JsonProperty("version")] public string? Version { get; }

    [JsonProperty("enabled")] public bool? Enabled { get; }

    [JsonProperty("configuration")] public Dictionary<string, object>? Configuration { get; } = new();
}