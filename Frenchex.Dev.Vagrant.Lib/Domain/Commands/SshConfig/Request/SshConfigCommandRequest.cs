using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Request;

public class SshConfigCommandRequest : RootCommandRequest, ISshConfigCommandRequest
{
    public SshConfigCommandRequest(
        string nameOrId,
        string host,
        IBaseCommandRequest baseRequest
    ) : base(baseRequest)
    {
        NameOrId = nameOrId;
        Host = host;
    }

    public string NameOrId { get; }
    public string Host { get; }
}