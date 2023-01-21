#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Destroy;

public class DestroyCommandIntegrationPayload : CommandIntegrationPayload
{
    public string[]? NameOrId { get; set; }
    public bool Force { get; set; }
    public bool Graceful { get; set; }
    public bool Parallel { get; set; }
}