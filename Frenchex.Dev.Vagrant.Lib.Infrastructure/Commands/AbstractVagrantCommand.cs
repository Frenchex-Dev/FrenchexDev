using Frenchex.Dev.DotnetCore.Process.Lib;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands;

public abstract class AbstractVagrantCommand
{
    protected readonly IProcess ProcessExecutor;

    protected AbstractVagrantCommand(
        IProcess processExecutor
    )
    {
        ProcessExecutor = processExecutor;
    }

    protected abstract string[] BuildVagrantArgumentsAndOptions(
        IVagrantCommandRequest request,
        IVagrantCommandExecutionContext context);

}