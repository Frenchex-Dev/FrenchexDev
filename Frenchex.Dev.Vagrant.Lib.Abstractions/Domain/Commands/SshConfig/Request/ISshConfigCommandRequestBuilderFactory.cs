﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;

public interface ISshConfigCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    ISshConfigCommandRequestBuilder Factory();
}