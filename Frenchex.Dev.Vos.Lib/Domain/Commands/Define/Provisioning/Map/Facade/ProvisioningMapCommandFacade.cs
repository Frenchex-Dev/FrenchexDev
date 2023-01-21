#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Facade;

public class DefineProvisioningMapCommandFacade : IDefineProvisioningMapCommandFacade
{
    public DefineProvisioningMapCommandFacade(
        IDefineProvisioningMapCommand command,
        IDefineProvisioningMapCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "map";
    }

    public IDefineProvisioningMapCommand Command { get; }
    public IDefineProvisioningMapCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IDefineProvisioningMapCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}