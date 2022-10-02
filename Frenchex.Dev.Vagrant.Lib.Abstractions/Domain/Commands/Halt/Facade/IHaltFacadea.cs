using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Facade;

public interface IHaltFacade : IFacade<IHaltCommand, IHaltCommandRequestBuilderFactory, IHaltCommandRequestBuilder>
{
}