#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Response;

public class ProvisionCommandResponseBuilderFactory : RootResponseBuilderFactory,
    IProvisionCommandResponseBuilderFactory
{
    public IProvisionCommandResponseBuilder Factory()
    {
        return new ProvisionCommandResponseBuilder();
    }
}