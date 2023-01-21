#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;

public class DefineProvisioningMapCommandRequestBuilderFactory : IDefineProvisioningMapCommandRequestBuilderFactory
{
    private readonly IBaseRequestBuilderFactory _baseRequestBuilderFactory;

    public DefineProvisioningMapCommandRequestBuilderFactory(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        _baseRequestBuilderFactory = baseRequestBuilderFactory;
    }

    public IDefineProvisioningMapCommandRequestBuilder Factory()
    {
        return new DefineProvisioningMapCommandRequestBuilder(_baseRequestBuilderFactory);
    }
}