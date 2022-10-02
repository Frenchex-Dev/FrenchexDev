using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;

public interface
    IDefineMachineTypeAddCommand : IAsyncCommand, IAsyncRootCommand<IDefineMachineTypeAddCommandRequest,
        IDefineMachineTypeAddCommandResponse>
{
}