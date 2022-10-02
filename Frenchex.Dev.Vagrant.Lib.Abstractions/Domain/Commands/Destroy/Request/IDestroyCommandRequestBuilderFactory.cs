
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IDestroyCommandRequestBuilder Factory();
}