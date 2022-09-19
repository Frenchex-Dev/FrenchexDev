using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Facade;

public class ProvisionFacade : IProvisionFacade
{
    public IProvisionCommand Command { get; }
    public IProvisionCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IProvisionCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}