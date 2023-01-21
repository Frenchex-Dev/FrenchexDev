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

public class MachineTypeDefinitionDeclaration
{
    [JsonProperty("base")] public MachineBaseDefinitionDeclaration? Base { get; set; }

    [JsonProperty("name")] public string? Name { get; set; }
}