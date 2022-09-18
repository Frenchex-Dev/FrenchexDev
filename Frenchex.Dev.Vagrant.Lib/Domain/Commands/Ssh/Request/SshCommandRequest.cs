using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Request;

public class SshCommandRequest : RootCommandRequest, ISshCommandRequest
{
    public SshCommandRequest(
        string nameOrId,
        string command,
        bool plain,
        string extraSshArgs,
        bool withColor,
        IBaseCommandRequest baseRequest
    ) : base(baseRequest)
    {
        NameOrId = nameOrId;
        Command = command;
        Plain = plain;
        ExtraSshArgs = extraSshArgs;
        WithColor = withColor;
    }

    public string NameOrId { get; }
    public string Command { get; }
    public bool Plain { get; }
    public string ExtraSshArgs { get; }
    public bool WithColor { get; }
}