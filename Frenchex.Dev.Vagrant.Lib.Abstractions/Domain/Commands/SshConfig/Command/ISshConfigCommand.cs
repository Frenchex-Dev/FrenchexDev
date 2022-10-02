using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;

public interface ISshConfigCommand : IFacableCommand, ICommand<ISshConfigCommandRequest, ISshConfigCommandResponse>
{
}