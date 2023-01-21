#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Facade;

public interface IDefineMachineTypeAddCommandFacade : IFacableCommand,
    IFacade<IDefineMachineTypeAddCommand, IDefineMachineTypeAddCommandRequestBuilderFactory,
        IDefineMachineTypeAddCommandRequestBuilder>
{
}