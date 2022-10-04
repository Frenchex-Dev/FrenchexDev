using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Facade;

public interface IDefineMachineTypeAddCommandFacade : IFacableCommand,
    IFacade<IDefineMachineTypeAddCommand, IDefineMachineTypeAddCommandRequestBuilderFactory,
        IDefineMachineTypeAddCommandRequestBuilder>
{
}