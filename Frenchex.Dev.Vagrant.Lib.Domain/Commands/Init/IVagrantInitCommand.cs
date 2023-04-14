using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

/// <summary>
/// 
/// </summary>
public interface IVagrantInitCommand : IVagrantCommand<VagrantInitRequest, VagrantInitResponse>
{
}