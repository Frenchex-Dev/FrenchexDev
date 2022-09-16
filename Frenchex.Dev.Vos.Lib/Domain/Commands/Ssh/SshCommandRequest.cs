using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh;

public class SshCommandRequest : RootRequest, ISshCommandRequest
{
    public SshCommandRequest(
        string[] namesOrIds,
        string[] command,
        bool plain,
        string extraSshArgs,
        IBaseRequest baseRequest
    ) : base(baseRequest)
    {
        NamesOrIds = namesOrIds;
        Commands = command;
        Plain = plain;
        ExtraSshArgs = extraSshArgs;
    }

    public string[] NamesOrIds { get; }
    public string[] Commands { get; }
    public bool Plain { get; }
    public string ExtraSshArgs { get; }
}