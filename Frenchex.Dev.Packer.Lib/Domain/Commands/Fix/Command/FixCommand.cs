using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Command;

public class FixCommand : IFixCommand
{
    public string GetCliCommandName()
    {
        return "fix";
    }

    public IFixCommandResponse StartProcess(IFixCommandRequest request)
    {
        throw new NotImplementedException();
    }
}