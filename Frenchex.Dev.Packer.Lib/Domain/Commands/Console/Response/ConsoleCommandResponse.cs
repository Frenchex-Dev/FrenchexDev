using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Response;

public class ConsoleCommandResponse : IConsoleCommandResponse
{
    public ConsoleCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}