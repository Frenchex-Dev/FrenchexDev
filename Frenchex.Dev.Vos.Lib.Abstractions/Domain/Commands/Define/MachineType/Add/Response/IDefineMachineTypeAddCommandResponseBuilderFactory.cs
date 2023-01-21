#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;

public interface IDefineMachineTypeAddCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IDefineMachineTypeAddCommandResponseBuilder Factory();
}