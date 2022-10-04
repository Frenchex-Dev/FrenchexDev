using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Request;

public class SshConfigCommandCommandRequest : RootCommandRequest, ISshConfigCommandRequest
{
    public SshConfigCommandCommandRequest(
        string[] namesOrIds,
        string host,
        IBaseCommandRequest baseCommandRequest
    ) : base(baseCommandRequest)
    {
        NamesOrIds = namesOrIds;
        Host = host;
    }

    public string[] NamesOrIds { get; }
    public string Host { get; }
}