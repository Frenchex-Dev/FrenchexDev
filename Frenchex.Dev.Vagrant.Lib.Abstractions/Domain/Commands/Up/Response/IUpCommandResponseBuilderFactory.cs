using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;

public interface IUpCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IUpCommandResponseBuilder Build();
}