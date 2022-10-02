using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Facade;

public class DefineMachineAddCommandFacade : IDefineMachineAddCommandFacade
{
    public DefineMachineAddCommandFacade(IDefineMachineAddCommand command, IDefineMachineAddCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "add";
    }

    public IDefineMachineAddCommand Command { get; }
    public IDefineMachineAddCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IDefineMachineAddCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}