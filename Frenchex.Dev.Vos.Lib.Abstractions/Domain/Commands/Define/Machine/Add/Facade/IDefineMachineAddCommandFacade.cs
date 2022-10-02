using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Facade;

public interface IDefineMachineAddCommandFacade : IFacableCommand, Domain.IFacade<IDefineMachineAddCommand, IDefineMachineAddCommandRequestBuilderFactory, IDefineMachineAddCommandRequestBuilder>
{
    
}