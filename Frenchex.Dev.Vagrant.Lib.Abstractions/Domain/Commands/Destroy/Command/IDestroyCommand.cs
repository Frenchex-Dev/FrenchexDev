using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;

public interface IDestroyCommand : IFaceableCommand, ICommand<IDestroyCommandRequest, IDestroyCommandResponse>
{
}