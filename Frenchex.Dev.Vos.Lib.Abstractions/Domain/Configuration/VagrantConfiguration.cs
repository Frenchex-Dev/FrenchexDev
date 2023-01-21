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

public class VagrantConfiguration
{
    [JsonProperty("prefix-with-dirbase")] public bool PrefixWithDirBase { get; set; }

    [JsonProperty("instance-number")] public int InstanceNumber { get; set; }

    [JsonProperty("zeroes")] public int Zeroes { get; set; } = 2;

    [JsonProperty("naming-pattern")] public string NamingPattern { get; set; } = "#MACHINE-NAME#-#MACHINE-INSTANCE#";

    [JsonProperty("plugins")] public Dictionary<string, VagrantPluginsConfiguration> Plugins { get; set; } = new();
}