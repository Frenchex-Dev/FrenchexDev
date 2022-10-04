﻿using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map;

public class DefineProvisioningMapCommandCommandResponseBuilder : IDefineProvisioningMapCommandCommandResponseBuilder
{
    public IDefineProvisioningMapCommandResponse Build()
    {
        return new DefineProvisioningMapCommandResponse();
    }
}