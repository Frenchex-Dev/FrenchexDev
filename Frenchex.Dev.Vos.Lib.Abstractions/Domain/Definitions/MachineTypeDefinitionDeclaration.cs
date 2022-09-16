using Newtonsoft.Json;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class MachineTypeDefinitionDeclaration
{
    [JsonProperty("base")] public MachineBaseDefinitionDeclaration? Base { get; set; }

    [JsonProperty("name")] public string? Name { get; set; }
}