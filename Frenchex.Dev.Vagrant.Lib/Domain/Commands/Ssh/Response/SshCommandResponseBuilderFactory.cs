using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Response;

public class SshCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, ISshCommandResponseBuilderFactory
{
    public ISshCommandResponseBuilder Build()
    {
        return new SshCommandResponseBuilder();
    }
}