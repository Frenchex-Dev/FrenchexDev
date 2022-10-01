using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;

public interface IConsoleCommand : IFacableCommand, ICommand<IConsoleCommandRequest, IConsoleCommandResponse>
{
}