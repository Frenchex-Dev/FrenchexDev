using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Facade;

public interface ISshConfigFacade : IFacade<ISshConfigCommand, ISshConfigCommandRequestBuilderFactory, ISshConfigCommandRequestBuilder>
{
}

