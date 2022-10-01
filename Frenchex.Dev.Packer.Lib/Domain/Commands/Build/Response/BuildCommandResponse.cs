using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Response;

public class BuildCommandResponse : IBuildCommandResponse
{
    public BuildCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}