#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Ssh;

public class SshCommandIntegrationPayload : CommandIntegrationPayload
{
    public string[]? NamesOrIds { get; init; }
    public string[]? Commands { get; init; }
    public bool? Plain { get; init; }
    public string? ExtraSshArgs { get; init; }
}