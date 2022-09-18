using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;

public class DestroyCommandRequest : RootCommandRequest, IDestroyCommandRequest
{
    public DestroyCommandRequest(
        string nameOrId,
        bool force,
        bool parallel,
        bool graceful,
        int destroyTimeoutInMiliSeconds,
        IBaseCommandRequest baseRequest
    ) : base(baseRequest)
    {
        NameOrId = nameOrId;
        Force = force;
        Parallel = parallel;
        Graceful = graceful;
        DestroyTimeoutInMiliSeconds = destroyTimeoutInMiliSeconds;
    }

    public string NameOrId { get; }
    public bool Force { get; }
    public bool Parallel { get; }
    public bool Graceful { get; }
    public int DestroyTimeoutInMiliSeconds { get; }
    public Dotnet.Wrapping.Lib.Domain.Commands.Root.IBaseCommandRequest Base { get; }
}