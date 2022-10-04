using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

public interface IAsyncRootCommand<in TU, TR>
    where TU : IRootCommandRequest
    where TR : IRootCommandResponse
{
    Task<TR> ExecuteAsync(TU request);
}