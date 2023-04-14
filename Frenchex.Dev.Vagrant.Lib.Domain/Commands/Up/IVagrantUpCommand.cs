using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

/// <summary>
/// Runs the up command for given request
/// </summary>
public interface IVagrantUpCommand : IVagrantCommand<UpCommandRequest, UpCommandResponse>
{
}