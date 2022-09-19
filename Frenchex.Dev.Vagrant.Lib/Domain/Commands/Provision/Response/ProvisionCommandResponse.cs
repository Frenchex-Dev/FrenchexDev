using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Response;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Response;

public class ProvisionCommandResponse : IProvisionCommandResponse
{
    public ProvisionCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}