using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Response;

public class SshConfigCommandResponseBuilderFactory : RootCommandResponseBuilderFactory,
    ISshConfigCommandResponseBuilderFactory
{
    public ISshConfigCommandResponseBuilder Build()
    {
        return new SshConfigCommandResponseBuilder();
    }
}