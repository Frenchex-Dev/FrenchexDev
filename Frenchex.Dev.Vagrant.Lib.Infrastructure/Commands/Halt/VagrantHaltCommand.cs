using Frenchex.Dev.DotnetCore.Process.Lib;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

namespace Frenchex.Dev.Vagrant.Lib.Infrastructure.Commands.Halt;

/// <summary>
/// 
/// </summary>
public class VagrantHaltCommand : AbstractVagrantCommand, IVagrantHaltCommand
{
    public VagrantHaltCommand(IProcess processExecutor) : base(processExecutor)
    {
    }

    public Task<HaltCommandResponse> StartAsync(HaltCommandRequest request, IVagrantCommandExecutionContext context,
        IVagrantCommandExecutionListeners listeners)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(TimeSpan timeOut)
    {
        throw new NotImplementedException();
    }
}