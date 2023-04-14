using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

/// <summary>
/// 
/// </summary>
public class HaltCommandResponse : BaseVagrantCommandResponse
{
    public HaltCommandResponse(int exitCode) : base(exitCode)
    {
    }
}