#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Response;

public class DefineProvisioningMapCommandResponseBuilderFactory : IDefineProvisioningMapCommandResponseBuilderFactory
{
    public IDefineProvisioningMapCommandResponseBuilder Factory()
    {
        return new DefineProvisioningMapCommandResponseBuilder();
    }
}