#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;

/// <summary>
///     Runs the up command for given request
/// </summary>
public interface IVagrantUpCommand : IVagrantCommand<VagrantUpRequest, IVagrantUpResponse>
{
}
