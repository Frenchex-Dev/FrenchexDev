using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Request;

public class DefineMachineTypeAddCommandRequest : IDefineMachineTypeAddCommandRequest
{
    public DefineMachineTypeAddCommandRequest(
        IBaseRequest baseRequest,
        MachineTypeDefinitionDeclaration definitionDeclaration
    )
    {
        Base = baseRequest;
        DefinitionDeclaration = definitionDeclaration;
    }

    public IBaseRequest Base { get; }

    public MachineTypeDefinitionDeclaration DefinitionDeclaration { get; }
}