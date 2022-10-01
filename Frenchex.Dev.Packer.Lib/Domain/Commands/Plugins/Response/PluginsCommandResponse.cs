using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Response;

public class PluginsCommandResponse : IPluginsCommandResponse
{
    public PluginsCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}