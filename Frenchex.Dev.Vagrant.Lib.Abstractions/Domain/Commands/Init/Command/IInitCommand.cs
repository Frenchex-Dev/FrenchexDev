using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;

public interface IInitCommand : IFacableCommand, ICommand<IInitCommandRequest, IInitCommandResponse>
{
}