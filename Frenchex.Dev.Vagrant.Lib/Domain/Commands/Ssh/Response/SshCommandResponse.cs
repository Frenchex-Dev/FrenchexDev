using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Response;

public class SshCommandResponse : RootResponse, ISshCommandResponse
{
    public SshCommandResponse(
        IProcess process,
        ProcessExecutionResult processExecutionResult
    ) : base(process, processExecutionResult)
    {
    }
}