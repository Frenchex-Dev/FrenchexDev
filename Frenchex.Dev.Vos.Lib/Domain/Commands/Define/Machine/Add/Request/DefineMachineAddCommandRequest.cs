using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Request;

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