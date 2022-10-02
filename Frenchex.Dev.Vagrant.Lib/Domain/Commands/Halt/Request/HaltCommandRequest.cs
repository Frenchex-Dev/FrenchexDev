using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Request;

public class HaltCommandRequest : RootCommandRequest, IHaltCommandRequest
{
    public HaltCommandRequest(
        string[] namesOrIds,
        bool force,
        IBaseCommandRequest baseRequest,
        String? haltTimeout
    ) : base(baseRequest)
    {
        NamesOrIds = namesOrIds;
        Force = force;
        HaltTimeout = haltTimeout;
    }
    public string? HaltTimeout { get; }
    public string[] NamesOrIds { get; }
    public bool Force { get; }
}