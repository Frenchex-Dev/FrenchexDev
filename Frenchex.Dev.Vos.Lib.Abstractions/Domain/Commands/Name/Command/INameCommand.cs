using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;

public interface INameCommand : IAsyncCommand, IAsyncRootCommand<INameCommandRequest, INameCommandResponse>
{
}