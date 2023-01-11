#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Request;

public class SshConfigCommandRequestBuilder : RootCommandRequestBuilder, ISshConfigCommandRequestBuilder
{
    private string? _host;
    private string[]? _namesOrIds;

    public SshConfigCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public ISshConfigCommandRequest Build()
    {
        return new SshConfigCommandCommandRequest(
            _namesOrIds ?? Array.Empty<string>(),
            _host ?? "",
            BaseBuilder.Build()
        );
    }

    public ISshConfigCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds)
    {
        _namesOrIds = namesOrIds;
        return this;
    }

    public ISshConfigCommandRequestBuilder UsingHost(string host)
    {
        _host = host;
        return this;
    }
}