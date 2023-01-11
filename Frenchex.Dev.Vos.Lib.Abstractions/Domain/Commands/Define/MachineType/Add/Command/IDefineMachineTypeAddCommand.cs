#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;

public interface
    IDefineMachineTypeAddCommand : IAsyncCommand, IAsyncRootCommand<IDefineMachineTypeAddCommandRequest,
        IDefineMachineTypeAddCommandResponse>
{
}