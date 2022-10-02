using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Response;

public class SshCommandResponseBuilderFactory : RootResponseBuilderFactory, ISshCommandResponseBuilderFactory
{
    public ISshCommandResponseBuilder Build()
    {
        return new SshCommandResponseBuilder();
    }
}