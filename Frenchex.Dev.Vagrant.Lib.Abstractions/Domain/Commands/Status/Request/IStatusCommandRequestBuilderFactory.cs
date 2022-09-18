namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;

public interface IStatusCommandRequestBuilderFactory
{
    IStatusCommandRequestBuilder Factory();
}