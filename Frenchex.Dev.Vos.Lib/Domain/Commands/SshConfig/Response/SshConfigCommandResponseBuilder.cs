using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Response;

public class SshConfigCommandResponseBuilder : RootResponseBuilder, ISshConfigCommandResponseBuilder
{
    public ISshConfigCommandResponse Build()
    {
        return new SshConfigCommandResponse();
    }
}