using Newtonsoft.Json;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class ProvisioningDefinition
{
    [JsonProperty("env")] public Dictionary<string, string>? Env { get; set; }
}