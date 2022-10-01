using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Command;

public interface IInspectCommand : IFacableCommand,
    ICommand<IInspectCommandRequest, IInspectCommandResponse>
{
}