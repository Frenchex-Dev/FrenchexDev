using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

public interface IUpCommand : ICommand<IUpCommandRequest, IUpCommandResponse>
{
}