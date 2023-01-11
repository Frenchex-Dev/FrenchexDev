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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Request;

public class DefineMachineAddCommandCommandRequest : RootCommandRequest, IDefineMachineAddCommandRequest
{
    public DefineMachineAddCommandCommandRequest(
        MachineDefinitionDeclaration machineDefinitionDeclaration,
        IBaseCommandRequest baseCommandRequest
    ) : base(baseCommandRequest)
    {
        DefinitionDeclaration = machineDefinitionDeclaration;
    }

    public MachineDefinitionDeclaration DefinitionDeclaration { get; }
}