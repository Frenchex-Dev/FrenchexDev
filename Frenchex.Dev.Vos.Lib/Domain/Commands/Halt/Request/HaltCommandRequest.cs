using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Request;

public class HaltCommandRequest : RootRequest, IHaltCommandRequest
{
    public HaltCommandRequest(
        string[] namesOrIds,
        bool force,
        bool parallel,
        bool graceful,
        IBaseRequest baseRequest,
        string? haltTimeout
    ) : base(baseRequest)
    {
        Names = namesOrIds;
        Force = force;
        Parallel = parallel;
        Graceful = graceful;
        HaltTimeout = haltTimeout;
    }

    public bool Parallel { get; }
    public bool Graceful { get; }
    public string[] Names { get; }
    public bool Force { get; }
    public string? HaltTimeout { get; }
}