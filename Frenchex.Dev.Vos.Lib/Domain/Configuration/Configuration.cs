using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Newtonsoft.Json;

namespace Frenchex.Dev.Vos.Lib.Domain.Configuration;

public class Configuration
{
    [JsonProperty("vagrant")] public VagrantConfiguration Vagrant { get; set; } = new();

    [JsonProperty("machine_types")] public Dictionary<string, MachineTypeDefinitionDeclaration> MachineTypes { get; set; } = new();

    [JsonProperty("machines")] public Dictionary<string, MachineDefinitionDeclaration> Machines { get; set; } = new();
}