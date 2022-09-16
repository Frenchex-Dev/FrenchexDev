using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;

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