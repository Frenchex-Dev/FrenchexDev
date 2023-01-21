﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Status;

public class StatusCommandIntegrationPayload : CommandIntegrationPayload
{
    public string[]? Names { get; set; }
}