using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Response;

public class RootResponse : IRootCommandResponse
{
    public RootResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }

    public ProcessExecutionResult ProcessExecutionResult { get; }
}