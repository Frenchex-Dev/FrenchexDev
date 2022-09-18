
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Facade;

public interface IUpFacade : IFacade<IUpCommand, IUpCommandRequestBuilderFactory, IUpCommandRequestBuilder>
{
    
}