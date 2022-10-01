using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;

public interface IFixCommand : IFacableCommand, ICommand<IFixCommandRequest, IFixCommandResponse>
{
}