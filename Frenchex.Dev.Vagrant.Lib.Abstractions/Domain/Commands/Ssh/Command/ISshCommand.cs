using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;

public interface ISshCommand : IFaceableCommand, ICommand<ISshCommandRequest, ISshCommandResponse>
{
}