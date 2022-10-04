using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;

public interface ISshConfigCommandCommandResponseBuilder : IRootCommandResponseBuilder
{
    ISshConfigCommandResponse Build();
}