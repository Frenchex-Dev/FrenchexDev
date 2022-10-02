using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Response;

public class SshConfigCommandResponseBuilderFactory : RootResponseBuilderFactory,
    ISshConfigCommandResponseBuilderFactory
{
    public ISshConfigCommandResponseBuilder Build()
    {
        return new SshConfigCommandResponseBuilder();
    }
}