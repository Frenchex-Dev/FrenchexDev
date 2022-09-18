using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Response;

public class UpCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IUpCommandResponseBuilderFactory
{
    public IUpCommandResponseBuilder Build()
    {
        return new UpCommandResponseBuilder();
    }
}