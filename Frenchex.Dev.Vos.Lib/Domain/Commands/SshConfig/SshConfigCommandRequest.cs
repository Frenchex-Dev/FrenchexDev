using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig;

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