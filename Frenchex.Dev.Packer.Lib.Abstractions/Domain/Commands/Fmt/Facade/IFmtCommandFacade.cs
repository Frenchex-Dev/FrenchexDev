using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Facade;

public interface IFmtCommandFacade : IFacableCommand,
    IFacade<IFmtCommand, IFmtCommandRequestBuilderFactory, IFmtCommandRequestBuilder>
{
}