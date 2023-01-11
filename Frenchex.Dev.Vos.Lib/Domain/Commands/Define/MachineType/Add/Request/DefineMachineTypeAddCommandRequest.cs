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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Request;

public class DefineMachineTypeAddCommandRequest : RootCommandRequest, IDefineMachineTypeAddCommandRequest
{
    public DefineMachineTypeAddCommandRequest(
        IBaseCommandRequest baseCommandRequest,
        MachineTypeDefinitionDeclaration definitionDeclaration
    ) : base(baseCommandRequest)
    {
        DefinitionDeclaration = definitionDeclaration;
    }

    public MachineTypeDefinitionDeclaration DefinitionDeclaration { get; }
}