#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IDefineProvisioningMapCommand, DefineProvisioningMapCommand>()
            .AddScoped<IDefineProvisioningMapCommandFacade, DefineProvisioningMapCommandFacade>()
            .AddScoped<IDefineProvisioningMapCommandRequestBuilder, DefineProvisioningMapCommandRequestBuilder>()
            .AddScoped<IDefineProvisioningMapCommandRequestBuilderFactory, DefineProvisioningMapCommandRequestBuilderFactory>()
            .AddScoped<IDefineProvisioningMapCommandResponseBuilder, DefineProvisioningMapCommandResponseBuilder>()
            .AddScoped<IDefineProvisioningMapCommandResponseBuilderFactory, DefineProvisioningMapCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}