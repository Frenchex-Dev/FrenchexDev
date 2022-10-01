using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;

public interface IFmtCommand : IFacableCommand,
    ICommand<IFmtCommandRequest, IFmtCommandResponse>
{
}