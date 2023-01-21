#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Response;

public class ProvisionCommandResponseBuilder : RootResponseBuilder, IProvisionCommandResponseBuilder
{
    private Vagrant.Lib.Abstractions.Domain.Commands.Provision.Response.IProvisionCommandResponse? _provisionCommandResponse;

    public Abstractions.Domain.Commands.Provision.Response.IProvisionCommandResponse Build()
    {
        if (null == _provisionCommandResponse) throw new InvalidOperationException("Up command response is null");

        return new ProvisionCommandResponse(_provisionCommandResponse);
    }

    public IProvisionCommandResponseBuilder WithProvisionResponse(Vagrant.Lib.Abstractions.Domain.Commands.Provision.Response.IProvisionCommandResponse response)
    {
        _provisionCommandResponse = response;
        return this;
    }
}