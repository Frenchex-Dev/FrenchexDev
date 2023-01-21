#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequest : IRootCommandRequest
{
    string NameOrId { get; }
    bool Force { get; }
    bool Parallel { get; }
    bool Graceful { get; }
    int DestroyTimeoutInMs { get; }
}