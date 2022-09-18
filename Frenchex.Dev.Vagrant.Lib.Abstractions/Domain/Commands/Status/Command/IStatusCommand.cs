using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;

public interface IStatusCommand : ICommand<IStatusCommandRequest, IStatusCommandResponse>
{
}