using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Response;

public class DestroyCommandResponse : RootResponse, IDestroyCommandResponse
{
    public DestroyCommandResponse(
        IProcess process,
        ProcessExecutionResult processExecutionResult
    ) : base(process, processExecutionResult)
    {
    }
}