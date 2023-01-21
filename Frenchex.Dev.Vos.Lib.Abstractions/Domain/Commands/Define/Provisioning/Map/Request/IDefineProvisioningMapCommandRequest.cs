#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

public interface IDefineProvisioningMapCommandRequest : IRootCommandRequest
{
    string[] Names { get; set; }
    string ProvisioningName { get; }
    IDictionary<string, string>? Env { get; }
    bool Enable { get; set; }
    bool Disable { get; set; }
    string Version { get; set; }
    bool Privileged { get; set; }
    bool MachineType { get; set; }
}