using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Response;

public class SshCommandResponseBuilder : RootResponseBuilder, ISshCommandResponseBuilder
{
    public ISshCommandResponse Build()
    {
        return new SshCommandResponse();
    }
}