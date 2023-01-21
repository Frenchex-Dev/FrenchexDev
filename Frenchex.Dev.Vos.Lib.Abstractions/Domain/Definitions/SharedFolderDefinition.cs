#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class SharedFolderDefinition
{
    [JsonProperty("host_path")] public string? HostPath { get; set; }

    [JsonProperty("guest_path")] public string? GuestPath { get; set; }

    [JsonProperty("enabled")] public bool? Enabled { get; set; }

    [JsonProperty("provider")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ProviderEnum? Provider { get; set; }
}