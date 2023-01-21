#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Request;

public class Hcl2UpgradeCommandRequestBuilderFactory : IHcl2UpgradeCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public Hcl2UpgradeCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IHcl2UpgradeCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IHcl2UpgradeCommandRequestBuilder>();
    }
}