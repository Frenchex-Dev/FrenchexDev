namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

public interface IAsyncRootCommand<in TU, TR>
    where TU : IRootCommandRequest
    where TR : IRootCommandResponse
{
    Task<TR> ExecuteAsync(TU request);
}