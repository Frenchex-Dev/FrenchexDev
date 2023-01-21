﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Request;

public class SshCommandRequestBuilder : RootCommandRequestBuilder, ISshCommandRequestBuilder
{
    private string[]? _commands;
    private string? _extraSshArgs;
    private string[]? _namesOrIds;
    private bool? _plain;

    public SshCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public ISshCommandRequest Build()
    {
        return new SshCommandCommandRequest(
            _namesOrIds ?? new string[] { },
            _commands ?? new string[] { },
            _plain ?? false,
            _extraSshArgs ?? "",
            BaseBuilder.Build()
        );
    }

    public ISshCommandRequestBuilder UsingNames(string[] namesOrId)
    {
        _namesOrIds = namesOrId;
        return this;
    }

    public ISshCommandRequestBuilder UsingCommands(string[] commands)
    {
        _commands = commands;
        return this;
    }

    public ISshCommandRequestBuilder WithPlain(bool with)
    {
        _plain = with;
        return this;
    }

    public ISshCommandRequestBuilder UsingExtraSshArgs(string extra)
    {
        _extraSshArgs = extra;
        return this;
    }
}