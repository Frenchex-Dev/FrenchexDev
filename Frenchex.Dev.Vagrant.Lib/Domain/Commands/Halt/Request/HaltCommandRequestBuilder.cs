#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Request;

public class HaltCommandRequestBuilder : RootCommandRequestBuilder, IHaltCommandRequestBuilder
{
    private string? _usingHaltTimeout;
    private string[]? _usingNamesOrIds;
    private bool? _withForce;

    public HaltCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IHaltCommandRequest Build()
    {
        return new HaltCommandRequest(
            _usingNamesOrIds ?? Array.Empty<string>(),
            _withForce ?? false,
            BaseBuilder.Build(),
            _usingHaltTimeout
        );
    }

    public IHaltCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds)
    {
        _usingNamesOrIds = namesOrIds;
        return this;
    }

    public IHaltCommandRequestBuilder UsingHaltTimeout(string? timeout)
    {
        _usingHaltTimeout = timeout;
        return this;
    }

    public IHaltCommandRequestBuilder WithForce(bool with)
    {
        _withForce = with;
        return this;
    }
}