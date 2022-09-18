using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponseBuilderFactory : RootCommandResponseBuilderFactory,
    IStatusCommandResponseBuilderFactory
{
    public IStatusCommandResponseBuilder Build()
    {
        return new StatusCommandResponseBuilder();
    }
}