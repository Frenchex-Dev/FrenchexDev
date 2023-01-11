#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Newtonsoft.Json;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class ProvisioningDefinition
{
    [JsonProperty("env")] public Dictionary<string, string>? Env { get; set; }

    [JsonProperty("version")] public string? Version { get; set; }

    [JsonProperty("privileged")] public bool? Privileged { get; set; }
}