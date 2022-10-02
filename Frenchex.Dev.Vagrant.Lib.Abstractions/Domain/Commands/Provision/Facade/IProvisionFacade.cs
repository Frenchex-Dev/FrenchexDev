using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Facade;

public interface IProvisionFacade : IFacade<IProvisionCommand, IProvisionCommandRequestBuilderFactory,
    IProvisionCommandRequestBuilder>
{
}