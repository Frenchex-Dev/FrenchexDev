using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Response;

public class SshConfigCommandCommandResponseBuilderFactory : RootCommandResponseBuilderFactory,
    ISshConfigCommandCommandResponseBuilderFactory
{
    public ISshConfigCommandCommandResponseBuilder Build()
    {
        return new SshConfigCommandCommandResponseBuilder();
    }
}