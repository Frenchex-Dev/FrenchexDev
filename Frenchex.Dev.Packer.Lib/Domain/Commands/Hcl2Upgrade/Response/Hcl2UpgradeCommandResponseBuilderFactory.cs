#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Response;

public class Hcl2UpgradeCommandResponseBuilderFactory : IHcl2UpgradeCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public Hcl2UpgradeCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IHcl2UpgradeCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IHcl2UpgradeCommandResponseBuilder>();
    }
}