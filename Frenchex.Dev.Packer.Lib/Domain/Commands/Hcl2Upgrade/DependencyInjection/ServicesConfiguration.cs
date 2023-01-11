#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IHcl2UpgradeCommand, Hcl2UpgradeCommand>()
            .AddScoped<IHcl2UpgradeCommandFacade, Hcl2UpgradeCommandFacade>()
            .AddScoped<IHcl2UpgradeCommandRequestBuilder, Hcl2UpgradeCommandRequestBuilder>()
            .AddScoped<IHcl2UpgradeCommandRequestBuilderFactory, Hcl2UpgradeCommandRequestBuilderFactory>()
            .AddScoped<IHcl2UpgradeCommandResponseBuilder, Hcl2UpgradeCommandResponseBuilder>()
            .AddScoped<IHcl2UpgradeCommandResponseBuilderFactory, Hcl2UpgradeCommandResponseBuilderFactory>()
            ;
    }
}