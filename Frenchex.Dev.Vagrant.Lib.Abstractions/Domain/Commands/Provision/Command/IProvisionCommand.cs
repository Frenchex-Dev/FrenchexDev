using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command;

public interface IProvisionCommand : IFacableCommand, ICommand<IProvisionCommandRequest, IProvisionCommandResponse>
{
}