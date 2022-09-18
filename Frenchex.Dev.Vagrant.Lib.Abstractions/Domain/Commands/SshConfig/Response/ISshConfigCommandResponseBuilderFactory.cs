using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Response;

public interface ISshConfigCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    ISshConfigCommandResponseBuilder Build();
}