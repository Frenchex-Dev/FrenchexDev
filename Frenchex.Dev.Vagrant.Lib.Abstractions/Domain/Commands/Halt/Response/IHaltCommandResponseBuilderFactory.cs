using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;

public interface IHaltCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IHaltCommandResponseBuilder Build();
}