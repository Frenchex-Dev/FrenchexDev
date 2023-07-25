#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

/// <summary>
/// </summary>
public interface IVagrantHaltCommand : IVagrantCommand<VagrantHaltRequest, VagrantHaltResponse>
{
}
