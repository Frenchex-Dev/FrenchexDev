using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

/// <summary>
/// 
/// </summary>
public interface IVagrantHaltCommand : IVagrantCommand<HaltCommandRequest, HaltCommandResponse>
{
}