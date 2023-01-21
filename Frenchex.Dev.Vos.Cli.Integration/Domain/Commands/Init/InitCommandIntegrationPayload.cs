#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Init;

public class InitCommandIntegrationPayload : CommandIntegrationPayload
{
#pragma warning disable CS8618
    public string Naming { get; set; }
#pragma warning restore CS8618
    public int Zeroes { get; set; }
}