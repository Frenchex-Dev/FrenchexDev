using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Facade;

public interface IDefineMachineAddCommandFacade : IFacableCommand,
    IFacade<IDefineMachineAddCommand, IDefineMachineAddCommandRequestBuilderFactory,
        IDefineMachineAddCommandRequestBuilder>
{
}