using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Command;

public class InspectCommand : IInspectCommand
{
    public string GetCliCommandName()
    {
        return "inspect";
    }


    public IInspectCommandResponse StartProcess(IInspectCommandRequest request)
    {
        throw new NotImplementedException();
    }
}