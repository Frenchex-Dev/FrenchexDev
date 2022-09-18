using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;

public interface ISshCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    ISshCommandResponseBuilder Build();
}