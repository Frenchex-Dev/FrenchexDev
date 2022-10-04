using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Command;

public interface ISshConfigCommand : IAsyncCommand,
    IAsyncRootCommand<ISshConfigCommandRequest, ISshConfigCommandResponse>
{
}