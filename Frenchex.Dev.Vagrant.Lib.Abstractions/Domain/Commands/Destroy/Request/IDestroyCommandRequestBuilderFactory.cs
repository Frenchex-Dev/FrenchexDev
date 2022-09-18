using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IDestroyCommandRequestBuilder Factory();
}