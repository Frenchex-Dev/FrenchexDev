using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Facade;

public interface
    IStatusFacade : IFacade<IStatusCommand, IStatusCommandRequestBuilderFactory, IStatusCommandRequestBuilder>
{
}