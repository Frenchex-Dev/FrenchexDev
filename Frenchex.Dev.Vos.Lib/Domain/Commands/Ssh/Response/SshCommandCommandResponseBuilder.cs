using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Response;

public class SshCommandCommandResponseBuilder : RootCommandResponseBuilder, ISshCommandCommandResponseBuilder
{
    public ISshCommandResponse Build()
    {
        return new SshCommandResponse();
    }
}