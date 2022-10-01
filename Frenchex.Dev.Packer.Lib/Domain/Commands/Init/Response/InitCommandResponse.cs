using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Response;

public class InitCommandResponse : IInitCommandResponse
{
    public InitCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}