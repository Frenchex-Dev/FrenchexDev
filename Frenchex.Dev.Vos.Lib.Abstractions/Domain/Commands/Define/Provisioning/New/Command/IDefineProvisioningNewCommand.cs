#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Command;

public interface
    IDefineProvisioningNewCommand : IAsyncRootCommand<IDefineProvisioningNewCommandRequest,
        IDefineProvisioningNewCommandResponse>
{
}