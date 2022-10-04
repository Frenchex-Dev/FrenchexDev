using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Facade;

public interface INameCommandFacade : IFacableCommand,
    IFacade<INameCommand, INameCommandRequestBuilderFactory, INameCommandRequestBuilder>
{
}