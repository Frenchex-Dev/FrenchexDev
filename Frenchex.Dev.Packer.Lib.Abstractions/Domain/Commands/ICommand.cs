using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands;

public interface ICommand<in TU, out TR>
    where TU : IRootCommandRequest
    where TR : IRootCommandResponse
{
    TR StartProcess(TU request);
}