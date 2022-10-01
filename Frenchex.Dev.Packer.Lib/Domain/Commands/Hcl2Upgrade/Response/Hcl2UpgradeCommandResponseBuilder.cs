using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Response;

public class Hcl2UpgradeCommandResponseBuilder : IFmtCommandResponseBuilder
{
    public IRootCommandResponseBuilder SetProcess(IProcess process)
    {
        throw new NotImplementedException();
    }

    public IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult)
    {
        throw new NotImplementedException();
    }

    public IFmtCommandResponse Build()
    {
        throw new NotImplementedException();
    }
}