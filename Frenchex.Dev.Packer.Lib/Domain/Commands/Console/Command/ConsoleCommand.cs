using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Command;

public class ConsoleCommand : IConsoleCommand
{
    public string GetCliCommandName()
    {
        return "console";
    }

    public IConsoleCommandResponse StartProcess(IConsoleCommandRequest request)
    {
        throw new NotImplementedException();
    }
}