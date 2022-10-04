using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Request;

public class DestroyCommandRequest : RootRequest, IDestroyCommandRequest
{
    public DestroyCommandRequest(
        string nameOrId,
        bool force,
        bool parallel,
        bool graceful,
        IBaseRequest baseRequest,
        string? destroyTimeout
    ) : base(baseRequest)
    {
        Name = nameOrId;
        Force = force;
        Parallel = parallel;
        Graceful = graceful;
        DestroyTimeout = destroyTimeout;
    }

    public string Name { get; }
    public bool Force { get; }
    public bool Parallel { get; }
    public bool Graceful { get; }
    public string? DestroyTimeout { get; }
}