using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh;

public interface ISshCommand : IAsyncRootCommand<ISshCommandRequest, ISshCommandResponse>
{
}