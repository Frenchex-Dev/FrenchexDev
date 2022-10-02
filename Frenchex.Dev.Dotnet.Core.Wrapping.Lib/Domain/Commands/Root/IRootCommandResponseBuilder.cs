using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public interface IRootCommandResponseBuilder
{
    IRootCommandResponseBuilder SetProcess(IProcess process);
    IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult);
}