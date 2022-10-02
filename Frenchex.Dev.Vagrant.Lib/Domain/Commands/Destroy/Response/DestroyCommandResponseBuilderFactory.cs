using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Response;

public class DestroyCommandResponseBuilderFactory : RootCommandResponseBuilderFactory,
    IDestroyCommandResponseBuilderFactory
{
    public IDestroyCommandResponseBuilder Build()
    {
        return new DestroyCommandResponseBuilder();
    }
}