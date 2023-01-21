#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning.Map;

public class DefineProvisioningMapCommandIntegrationPayload : CommandIntegrationPayload
{
    public string? MachineName { get; set; }
    public bool? MachineType { get; set; }
    public string? Provision { get; set; }
    public bool Enable { get; set; }
    public string? Version { get; set; }
}