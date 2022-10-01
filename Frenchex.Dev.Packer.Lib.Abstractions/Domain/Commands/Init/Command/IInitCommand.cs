using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Command;

public interface IInitCommand : IFacableCommand,
    ICommand<IInitCommandRequest, IInitCommandResponse>
{
}