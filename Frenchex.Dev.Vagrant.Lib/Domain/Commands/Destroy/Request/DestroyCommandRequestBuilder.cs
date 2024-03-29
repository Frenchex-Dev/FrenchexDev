﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;

public class DestroyCommandRequestBuilder : RootCommandRequestBuilder, IDestroyCommandRequestBuilder
{
    private int? _withDestroyTimeoutMs;
    private bool? _withForce;
    private bool? _withGraceful;
    private string? _withNameOrId;
    private bool? _withParallel;

    public DestroyCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IDestroyCommandRequest Build()
    {
        return new DestroyCommandRequest(
            _withNameOrId ?? "",
            _withForce ?? false,
            _withParallel ?? false,
            _withGraceful ?? false,
            _withDestroyTimeoutMs ?? 1000,
            BaseBuilder.Build()
        );
    }

    public IDestroyCommandRequestBuilder UsingName(string nameOrId)
    {
        _withNameOrId = nameOrId;
        return this;
    }

    public IDestroyCommandRequestBuilder WithForce(bool force)
    {
        _withForce = force;
        return this;
    }

    public IDestroyCommandRequestBuilder UsingDestroyTimeoutMiliseconds(int timeoutMs)
    {
        _withDestroyTimeoutMs = timeoutMs;
        return this;
    }

    public IDestroyCommandRequestBuilder WithGraceful(bool graceful)
    {
        _withGraceful = graceful;
        return this;
    }

    public IDestroyCommandRequestBuilder WithParallel(bool parallel)
    {
        _withParallel = parallel;
        return this;
    }
}