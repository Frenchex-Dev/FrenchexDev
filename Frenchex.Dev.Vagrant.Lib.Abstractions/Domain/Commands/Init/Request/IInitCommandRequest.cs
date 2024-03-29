﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequest : IRootCommandRequest
{
    string? BoxName { get; }
    string? BoxVersion { get; }
    bool? Force { get; }
    bool? Minimal { get; }
    string? OutputToFile { get; }
    string? TemplateFile { get; }
}