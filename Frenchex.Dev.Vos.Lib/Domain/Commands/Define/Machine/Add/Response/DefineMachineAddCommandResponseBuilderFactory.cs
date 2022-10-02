using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Response;

public class DefineMachineAddCommandResponseBuilderFactory : IDefineMachineAddCommandResponseBuilderFactory
{
    public IDefineMachineAddCommandResponseBuilder Factory()
    {
        return new DefineMachineAddCommandResponseBuilder();
    }
}