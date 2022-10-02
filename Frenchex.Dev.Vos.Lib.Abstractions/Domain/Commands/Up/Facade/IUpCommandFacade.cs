using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Facade;

public interface IUpCommandFacade : IFacableCommand,
    Domain.IFacade<IUpCommand, IUpCommandRequestBuilderFactory, IUpCommandRequestBuilder>
{
}