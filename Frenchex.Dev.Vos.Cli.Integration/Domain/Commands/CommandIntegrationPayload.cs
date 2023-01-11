#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;

public class CommandIntegrationPayload
{
    public string? VagrantBinPath { get; init; }
    public string? WorkingDirectory { get; init; }
    public string? TimeoutString { get; init; }
}