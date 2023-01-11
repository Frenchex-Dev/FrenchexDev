#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Request;

public class ProvisionCommandRequestBuilder : RootCommandRequestBuilder, IProvisionCommandRequestBuilder
{
    private string? _vmName;
    private string[]? _with;

    public ProvisionCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory? baseRequestBuilderFactory
    ) : base(
        baseRequestBuilderFactory)
    {
    }

    public IProvisionCommandRequest Build()
    {
        return new ProvisionCommandRequest(BaseBuilder.Build(), _vmName, _with);
    }

    public IProvisionCommandRequestBuilder ProvisionWith(string[] with)
    {
        _with = with;
        return this;
    }

    public IProvisionCommandRequestBuilder ProvisionVmName(string vmName)
    {
        _vmName = vmName;
        return this;
    }
}