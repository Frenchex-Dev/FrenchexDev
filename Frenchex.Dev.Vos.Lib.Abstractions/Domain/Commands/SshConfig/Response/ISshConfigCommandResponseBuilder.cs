using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;

public interface ISshConfigCommandResponseBuilder : IRootResponseBuilder
{
    ISshConfigCommandResponse Build();
}