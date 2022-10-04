﻿using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Request;

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