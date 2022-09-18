using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Facade;

public interface IInitFacade : IFacade<IInitCommand, IInitCommandRequestBuilderFactory, IInitCommandRequestBuilder>
{
}

