﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

public interface ISshConfigCommandRequestBuilder : IRootCommandRequestBuilder
{
    ISshConfigCommandRequest Build();
    ISshConfigCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds);
    ISshConfigCommandRequestBuilder UsingHost(string host);
}