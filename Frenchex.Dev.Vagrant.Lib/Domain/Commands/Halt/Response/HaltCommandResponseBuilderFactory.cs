using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Response;

public class HaltCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IHaltCommandResponseBuilderFactory
{
    public IHaltCommandResponseBuilder Build()
    {
        return new HaltCommandResponseBuilder();
    }
}