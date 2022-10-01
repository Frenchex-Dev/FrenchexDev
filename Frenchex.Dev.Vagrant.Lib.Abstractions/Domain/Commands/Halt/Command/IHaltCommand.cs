using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;

public interface IHaltCommand : IFacableCommand, ICommand<IHaltCommandRequest, IHaltCommandResponse>
{
}