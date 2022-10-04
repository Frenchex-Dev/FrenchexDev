using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Response;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Response;

public abstract class RootResponseBuilder : IRootCommandResponseBuilder
{
    protected IProcess? Process;
    protected ProcessExecutionResult? ProcessExecutionResult;

    public IRootCommandResponseBuilder SetProcess(IProcess process)
    {
        Process = process;
        return this;
    }

    public IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult)
    {
        ProcessExecutionResult = processExecutionResult;
        return this;
    }
}