using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands;

public interface ICommand<in TU, out TR>
    where TU : IRootCommandRequest
    where TR : IRootCommandResponse
{
    TR StartProcess(TU request);
}