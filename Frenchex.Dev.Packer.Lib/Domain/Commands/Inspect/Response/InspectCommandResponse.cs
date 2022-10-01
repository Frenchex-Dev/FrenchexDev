using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Response;

public class InspectCommandResponse : IInspectCommandResponse
{
    public InspectCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}