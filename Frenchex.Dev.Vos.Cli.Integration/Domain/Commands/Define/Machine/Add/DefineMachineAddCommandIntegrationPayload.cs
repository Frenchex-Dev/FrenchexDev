#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine.Add;

public class DefineMachineAddCommandIntegrationPayload : CommandIntegrationPayload
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int Instances { get; set; }
    public string? NamingPattern { get; set; }
    public bool IsPrimary { get; set; }
    public bool Enabled { get; set; }
    public int VCpus { get; set; }
    public int RamInMb { get; set; }

    // ReSharper disable once InconsistentNaming
    public string? IPv4Pattern { get; set; }

    // ReSharper disable once InconsistentNaming
    public int IPv4Start { get; set; }
    public string? NetworkBridge { get; set; }
}