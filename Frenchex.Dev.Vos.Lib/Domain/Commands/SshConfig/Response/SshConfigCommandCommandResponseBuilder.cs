using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Response;

public class SshConfigCommandCommandResponseBuilder : RootCommandResponseBuilder, ISshConfigCommandCommandResponseBuilder
{
    public ISshConfigCommandResponse Build()
    {
        return new SshConfigCommandResponse();
    }
}