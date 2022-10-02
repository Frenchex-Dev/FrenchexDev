using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;

public interface ISshCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    ISshCommandRequestBuilder Factory();
}