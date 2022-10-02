using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Response;

public class DefineMachineAddCommandResponseBuilder : IDefineMachineAddCommandResponseBuilder
{
    public IDefineMachineAddCommandResponse Build()
    {
        return new DefineMachineAddCommandResponse();
    }
}