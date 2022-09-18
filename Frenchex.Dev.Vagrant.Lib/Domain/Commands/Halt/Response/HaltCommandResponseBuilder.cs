using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Response;

public class HaltCommandResponseBuilder : RootResponseBuilder, IHaltCommandResponseBuilder
{
    public IHaltCommandResponse Build()
    {
        if (null == Process || null == ProcessExecutionResult)
            throw new InvalidOperationException("process or execution result is null");

        return new HaltCommandResponse(Process, ProcessExecutionResult);
    }
}