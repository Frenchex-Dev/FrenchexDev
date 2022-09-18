using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;

public interface IInitCommandResponseBuilder : IRootCommandResponseBuilder
{
    IInitCommandResponse Build();
}