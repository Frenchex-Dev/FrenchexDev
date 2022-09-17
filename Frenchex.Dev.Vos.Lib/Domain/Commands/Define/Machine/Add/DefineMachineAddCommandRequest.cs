using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add;

public class DefineMachineAddCommandRequest : RootRequest, IDefineMachineAddCommandRequest
{
    public DefineMachineAddCommandRequest(
        MachineDefinitionDeclaration machineDefinitionDeclaration,
        IBaseRequest baseRequest
    ) : base(baseRequest)
    {
        DefinitionDeclaration = machineDefinitionDeclaration;
    }

    public MachineDefinitionDeclaration DefinitionDeclaration { get; }
}