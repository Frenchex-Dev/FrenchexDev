#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

/// <summary>
/// </summary>
public class UpCommandResponse : BaseVagrantCommandResponse, IUpCommandResponse
{
    public UpCommandResponse(int exitCode) : base(exitCode)
    {
    }
}
