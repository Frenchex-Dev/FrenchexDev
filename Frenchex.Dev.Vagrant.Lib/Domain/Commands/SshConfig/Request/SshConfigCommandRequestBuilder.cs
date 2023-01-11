#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Request;

public class SshConfigCommandRequestBuilder : RootCommandRequestBuilder, ISshConfigCommandRequestBuilder
{
    private string? _host;
    private string? _nameOrId;

    public SshConfigCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public ISshConfigCommandRequest Build()
    {
        return new SshConfigCommandRequest(
            _nameOrId ?? "",
            _host ?? "",
            BaseBuilder.Build()
        );
    }

    public ISshConfigCommandRequestBuilder UsingName(string nameOrId)
    {
        _nameOrId = nameOrId;
        return this;
    }

    public ISshConfigCommandRequestBuilder UsingHost(string host)
    {
        _host = host;
        return this;
    }
}