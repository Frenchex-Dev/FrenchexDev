using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Response;

public interface IRootCommandResponse
{
    IProcess Process { get; }
    ProcessExecutionResult ProcessExecutionResult { get; }
}