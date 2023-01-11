#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;

public interface IDefineMachineTypeAddCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineMachineTypeAddCommandRequestBuilder UsingDefinition(MachineTypeDefinitionDeclaration definitionDeclaration);
    IDefineMachineTypeAddCommandRequest Build();
}