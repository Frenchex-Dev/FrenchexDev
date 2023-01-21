#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Newtonsoft.Json;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class FileCopyDefinition
{
    public FileCopyDefinition(string hostSource, string guestTarget, bool enabled)
    {
        HostSource = hostSource;
        GuestTarget = guestTarget;
        Enabled = enabled;
    }

    [JsonProperty("host_source")] public string HostSource { get; }

    [JsonProperty("guest_target")] public string GuestTarget { get; }

    [JsonProperty("enabled")] public bool Enabled { get; }
}