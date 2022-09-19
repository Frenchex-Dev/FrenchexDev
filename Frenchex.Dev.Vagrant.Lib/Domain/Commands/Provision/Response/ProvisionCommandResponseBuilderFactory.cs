using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Response;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Response;

public class ProvisionCommandResponseBuilderFactory : IProvisionCommandResponseBuilderFactory
{
    public IProvisionCommandResponseBuilder Build()
    {
        return new ProvisionCommandResponseBuilder();
    }
}