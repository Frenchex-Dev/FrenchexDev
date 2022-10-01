using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Command;

public class InitCommand : IInitCommand
{
    public string GetCliCommandName()
    {
        return "init";
    }

    public IInitCommandResponse StartProcess(IInitCommandRequest request)
    {
        throw new NotImplementedException();
    }
}