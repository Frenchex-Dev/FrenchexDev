#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;

public class DestroyCommandRequest : RootCommandRequest, IDestroyCommandRequest
{
    public DestroyCommandRequest(
        string nameOrId,
        bool force,
        bool parallel,
        bool graceful,
        int destroyTimeoutInMs,
        IBaseCommandRequest baseRequest
    ) : base(baseRequest)
    {
        NameOrId = nameOrId;
        Force = force;
        Parallel = parallel;
        Graceful = graceful;
        DestroyTimeoutInMs = destroyTimeoutInMs;
    }

    public string NameOrId { get; }
    public bool Force { get; }
    public bool Parallel { get; }
    public bool Graceful { get; }
    public int DestroyTimeoutInMs { get; }
}