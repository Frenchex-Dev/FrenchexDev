#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Response;

public class DefineMachineTypeAddCommandResponseBuilderFactory : IDefineMachineTypeAddCommandResponseBuilderFactory
{
    public IDefineMachineTypeAddCommandResponseBuilder Factory()
    {
        return new DefineMachineTypeAddCommandResponseBuilder();
    }
}