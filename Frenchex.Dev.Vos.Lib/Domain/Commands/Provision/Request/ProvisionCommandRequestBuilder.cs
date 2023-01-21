#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Request;

public class ProvisionCommandRequestBuilder : RootCommandRequestBuilder, IProvisionCommandRequestBuilder
{
    private string[]? _names;
    private string[]? _provisionWith;
    private bool? _enabled;

    public ProvisionCommandRequestBuilder(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public IProvisionCommandRequest Build()
    {
        return new ProvisionCommandRequest(
            namesOrIds: _names ?? Array.Empty<string>(),
            provisionWith: _provisionWith ?? Array.Empty<string>(),
            provision: _enabled ?? true,
            destroyOnError: false,
            baseCommandRequest: BaseBuilder.Build(),
            parallel: true,
            parallelWait: 1,
            parallelWorkers: 1,
            provider: ProviderEnum.Virtualbox.ToString().ToLowerInvariant(),
            installProvider: false,
            minimal: false
        );
    }

    public IProvisionCommandRequestBuilder UsingNames(string[] names)
    {
        _names = names;
        return this;
    }

    public IProvisionCommandRequestBuilder UsingProvisionWith(string[] provisionWith)
    {
        _provisionWith = provisionWith;
        return this;
    }

    public IProvisionCommandRequestBuilder Enable()
    {
        _enabled = true;
        return this;
    }

    public IProvisionCommandRequestBuilder Disable()
    {
        _enabled = false;
        return this;
    }
}