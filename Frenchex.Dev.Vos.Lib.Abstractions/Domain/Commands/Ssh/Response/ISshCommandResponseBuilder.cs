using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;

public interface ISshCommandResponseBuilder : IRootResponseBuilder
{
    ISshCommandResponse Build();
}