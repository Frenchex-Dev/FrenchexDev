using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;

public interface IDestroyCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IDestroyCommandResponseBuilder Build();
}