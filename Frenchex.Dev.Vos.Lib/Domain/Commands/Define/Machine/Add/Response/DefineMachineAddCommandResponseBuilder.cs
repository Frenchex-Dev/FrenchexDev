#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Response;

public class DefineMachineAddCommandResponseBuilder : IDefineMachineAddCommandResponseBuilder
{
    public IDefineMachineAddCommandResponse Build()
    {
        return new DefineMachineAddCommandResponse();
    }
}