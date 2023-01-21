#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Facade;

public interface IDefineMachineAddCommandFacade : IFacableCommand,
    IFacade<IDefineMachineAddCommand, IDefineMachineAddCommandRequestBuilderFactory,
        IDefineMachineAddCommandRequestBuilder>
{
}