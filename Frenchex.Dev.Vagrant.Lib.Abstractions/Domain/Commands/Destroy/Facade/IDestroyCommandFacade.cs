using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Facade;

public interface
    IDestroyCommandFacade : IFacade<IDestroyCommand, IDestroyCommandRequestBuilderFactory, IDestroyCommandRequestBuilder>
{
}