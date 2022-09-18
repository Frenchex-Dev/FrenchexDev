using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Response;

public class SshCommandResponseBuilder : RootResponseBuilder, ISshCommandResponseBuilder
{
    public ISshCommandResponse Build()
    {
        if (null == Process || null == ProcessExecutionResult)
            throw new InvalidOperationException("process or processexecutionresult is null");

        return new SshCommandResponse(Process, ProcessExecutionResult);
    }
}