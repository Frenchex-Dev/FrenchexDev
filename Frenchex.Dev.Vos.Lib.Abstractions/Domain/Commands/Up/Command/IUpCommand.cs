using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;

public interface IUpCommand : IAsyncCommand, IAsyncRootCommand<IUpCommandRequest, IUpCommandResponse>
{
}