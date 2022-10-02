using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;

public interface ISshCommand : IAsyncCommand, IAsyncRootCommand<ISshCommandRequest, ISshCommandResponse>
{
}