using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IInitCommandRequestBuilder Factory();
}