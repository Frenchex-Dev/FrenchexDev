using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;

public interface IHaltCommand : IAsyncCommand, IAsyncRootCommand<IHaltCommandRequest, IHaltCommandResponse>
{
}