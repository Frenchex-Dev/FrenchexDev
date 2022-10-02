namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;

public interface IProvisionCommandRequestBuilderFactory
{
    IProvisionCommandRequestBuilder Factory();
}