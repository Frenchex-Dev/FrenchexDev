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
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;

public class UpCommandRequestBuilder : RootCommandRequestBuilder, IUpCommandRequestBuilder
{
    private bool? _destroyOnError;
    private bool? _installProvider;
    private bool? _minimal;
    private string[]? _namesOrIds;
    private bool? _parallel;
    private string? _provider;
    private bool? _provision;
    private string[]? _provisionWith;

    public UpCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IUpCommandRequest Build()
    {
        return new UpCommandRequest(
            _namesOrIds ?? Array.Empty<string>(),
            _provision ?? false,
            _provisionWith ?? Array.Empty<string>(),
            _destroyOnError ?? false,
            _parallel ?? false,
            _provider ?? "",
            _installProvider ?? false,
            _minimal ?? false,
            BaseBuilder.Build()
        );
    }

    public IUpCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds)
    {
        _namesOrIds = namesOrIds;
        return this;
    }

    public IUpCommandRequestBuilder WithDestroyOnError(bool with)
    {
        _destroyOnError = with;
        return this;
    }

    public IUpCommandRequestBuilder WithProvision(bool with)
    {
        _provision = with;
        return this;
    }

    public IUpCommandRequestBuilder UsingProvisionWith(string[] provisionWith)
    {
        _provisionWith = provisionWith;
        return this;
    }

    public IUpCommandRequestBuilder WithParallel(bool with)
    {
        _parallel = with;
        return this;
    }

    public IUpCommandRequestBuilder UsingProvider(string provider)
    {
        _provider = provider;
        return this;
    }

    public IUpCommandRequestBuilder WithInstallProvider(bool with)
    {
        _installProvider = with;
        return this;
    }

    public IUpCommandRequestBuilder WithMinimal(bool with)
    {
        _minimal = with;
        return this;
    }
}