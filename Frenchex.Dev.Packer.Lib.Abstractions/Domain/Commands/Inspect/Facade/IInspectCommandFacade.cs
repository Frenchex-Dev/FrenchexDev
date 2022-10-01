using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Facade;

public interface IInspectCommandFacade : IFacableCommand,
    IFacade<IInspectCommand, IInspectCommandRequestBuilderFactory, IInspectCommandRequestBuilder>
{
}