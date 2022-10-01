using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Response;

public class FmtCommandResponse : IFmtCommandResponse
{
    public FmtCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}