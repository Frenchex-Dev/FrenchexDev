using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Request;

public class DefineMachineTypeAddCommandRequest : IDefineMachineTypeAddCommandRequest
{
    public DefineMachineTypeAddCommandRequest(
        IBaseCommandRequest baseCommandRequest,
        MachineTypeDefinitionDeclaration definitionDeclaration
    )
    {
        BaseCommand = baseCommandRequest;
        DefinitionDeclaration = definitionDeclaration;
    }

    public IBaseCommandRequest BaseCommand { get; }

    public MachineTypeDefinitionDeclaration DefinitionDeclaration { get; }
}