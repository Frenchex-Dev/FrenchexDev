using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Response;

public class Hcl2UpgradeCommandResponse : IFmtCommandResponse
{
    public Hcl2UpgradeCommandResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }
    public ProcessExecutionResult ProcessExecutionResult { get; }
}