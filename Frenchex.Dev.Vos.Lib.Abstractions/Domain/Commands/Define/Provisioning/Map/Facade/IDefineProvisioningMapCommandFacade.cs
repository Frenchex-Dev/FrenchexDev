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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Facade;

public interface IDefineProvisioningMapCommandFacade : IFacableCommand,
    IFacade<IDefineProvisioningMapCommand, IDefineProvisioningMapCommandRequestBuilderFactory,
        IDefineProvisioningMapCommandRequestBuilder>
{
}