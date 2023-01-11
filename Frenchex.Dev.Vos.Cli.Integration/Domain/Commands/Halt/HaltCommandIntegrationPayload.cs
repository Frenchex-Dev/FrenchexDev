#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Halt;

public class HaltCommandIntegrationPayload : CommandIntegrationPayload
{
    public string[]? Names { get; set; }
    public bool Force { get; set; }
    public string? HaltTimeout { get; set; }
}