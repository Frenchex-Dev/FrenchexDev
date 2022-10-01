using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Command;

public class FmtCommand : IFmtCommand
{
    public string GetCliCommandName()
    {
        return "fmt";
    }

    public IFmtCommandResponse StartProcess(IFmtCommandRequest request)
    {
        throw new NotImplementedException();
    }
}