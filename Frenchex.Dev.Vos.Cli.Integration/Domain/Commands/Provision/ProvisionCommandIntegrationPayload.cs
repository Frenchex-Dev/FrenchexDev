#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Provision;

public class ProvisionCommandIntegrationPayload : CommandIntegrationPayload
{
    public string[]? Names { get; set; }
    public bool Provision { get; set; }
    public string[]? ProvisionWith { get; set; }
}