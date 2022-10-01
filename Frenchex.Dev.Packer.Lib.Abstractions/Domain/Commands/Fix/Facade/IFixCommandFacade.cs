using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Facade;

public interface
    IFixCommandFacade : IFacableCommand, IFacade<IFixCommand, IFixCommandRequestBuilderFactory,
        IFixCommandRequestBuilder>
{
}