using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;

public interface IStatusCommandResponseBuilder : IRootCommandResponseBuilder
{
    IStatusCommandResponse Build();
}