using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IHaltCommandRequestBuilder Factory();
}