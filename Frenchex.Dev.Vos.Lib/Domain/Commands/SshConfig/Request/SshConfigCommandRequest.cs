using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Request;

public class SshConfigCommandRequest : RootRequest, ISshConfigCommandRequest
{
    public SshConfigCommandRequest(
        string[] namesOrIds,
        string host,
        IBaseRequest baseRequest
    ) : base(baseRequest)
    {
        NamesOrIds = namesOrIds;
        Host = host;
    }

    public string[] NamesOrIds { get; }
    public string Host { get; }
}