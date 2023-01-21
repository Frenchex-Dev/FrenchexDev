#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Request;

public class HaltCommandRequestBuilder : RootCommandRequestBuilder, IHaltCommandRequestBuilder
{
    private string? _usingHaltTimeout;
    private string[]? _usingNamesOrIds;
    private bool? _withForce;
    private bool? _withGraceful;
    private bool? _withParallel;

    public HaltCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IHaltCommandRequest Build()
    {
        return new HaltCommandCommandRequest(
            _usingNamesOrIds ?? Array.Empty<string>(),
            _withForce ?? false,
            _withParallel ?? false,
            _withGraceful ?? false,
            BaseBuilder.Build(),
            _usingHaltTimeout
        );
    }

    public IHaltCommandRequestBuilder UsingNames(string[]? namesOrIds)
    {
        _usingNamesOrIds = namesOrIds;
        return this;
    }

    public IHaltCommandRequestBuilder WithForce(bool with)
    {
        _withForce = with;
        return this;
    }

    public IHaltCommandRequestBuilder UsingHaltTimeout(string? timeout)
    {
        _usingHaltTimeout = timeout;
        return this;
    }

    public IHaltCommandRequestBuilder WithParallel(bool with)
    {
        _withParallel = with;
        return this;
    }

    public IHaltCommandRequestBuilder WithGraceful(bool with)
    {
        _withGraceful = with;
        return this;
    }
}