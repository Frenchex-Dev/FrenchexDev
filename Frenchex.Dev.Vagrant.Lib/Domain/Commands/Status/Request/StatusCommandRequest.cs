using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Request;

public class StatusCommandRequest : RootCommandRequest, IStatusCommandRequest
{
    public StatusCommandRequest(
        IBaseCommandRequest baseRequest,
        string[] namesOrIds
    ) : base(baseRequest)
    {
        NamesOrIds = namesOrIds;
    }

    public string[] NamesOrIds { get; }
}