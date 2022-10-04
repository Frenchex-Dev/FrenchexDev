using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Facade;

public class DefineMachineTypeAddCommandFacade : IDefineMachineTypeAddCommandFacade
{
    public DefineMachineTypeAddCommandFacade(
        IDefineMachineTypeAddCommand command,
        IDefineMachineTypeAddCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "add";
    }

    public IDefineMachineTypeAddCommand Command { get; }
    public IDefineMachineTypeAddCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IDefineMachineTypeAddCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}