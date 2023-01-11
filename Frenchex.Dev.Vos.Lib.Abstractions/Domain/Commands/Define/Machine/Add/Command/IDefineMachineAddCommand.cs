#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;

public interface
    IDefineMachineAddCommand : IAsyncCommand,
        IAsyncRootCommand<IDefineMachineAddCommandRequest, IDefineMachineAddCommandResponse>
{
}