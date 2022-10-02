using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;

public interface ISshConfigCommandResponseBuilder : IRootResponseBuilder
{
    ISshConfigCommandResponse Build();
}