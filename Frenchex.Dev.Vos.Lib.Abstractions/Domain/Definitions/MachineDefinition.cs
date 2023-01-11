﻿#region Licensing

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

public class MachineDefinitionDeclaration
{
    [JsonProperty("base")] public MachineBaseDefinitionDeclaration? Base { get; set; }

    [JsonProperty("machine_type_name")] public string? MachineTypeName { get; set; }

    [JsonProperty("name")] public string? Name { get; set; }

    [JsonProperty("naming_pattern")] public string? NamingPattern { get; set; } = "#VDI#-#NAME#-#INSTANCE#";

    [JsonProperty("instances")] public int? Instances { get; set; } = 1;

    [JsonProperty("ram_mb")] public int? RamInMb { get; set; } = 128;

    [JsonProperty("cpus")] public int? VirtualCpus { get; set; } = 2;

    [JsonProperty("ipv4_pattern")] public string? Ipv4Pattern { get; set; } = "10.100.1.#NUMBER#";

    [JsonProperty("ipv4_start")] public int? Ipv4Start { get; set; } = 2;

    [JsonProperty("is_primary")] public bool? IsPrimary { get; set; } = false;

    [JsonProperty("is_enabled")] public bool? IsEnabled { get; set; } = true;

    [JsonProperty("network_bridge")] public string? NetworkBridge { get; set; }
}