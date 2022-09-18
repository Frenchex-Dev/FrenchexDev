namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilderFactory
{
    IHaltCommandRequestBuilder Factory();
}