#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Request;

public class ProvisionCommandRequestBuilderFactory : RootCommandRequestBuilderFactory,
    IProvisionCommandRequestBuilderFactory
{
    public ProvisionCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IProvisionCommandRequestBuilder Factory()
    {
        return new ProvisionCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}