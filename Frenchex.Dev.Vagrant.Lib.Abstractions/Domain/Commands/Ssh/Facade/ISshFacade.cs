using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Facade;

public interface ISshFacade : IFacade<ISshCommand, ISshCommandRequestBuilderFactory, ISshCommandRequestBuilder>
{
    
}