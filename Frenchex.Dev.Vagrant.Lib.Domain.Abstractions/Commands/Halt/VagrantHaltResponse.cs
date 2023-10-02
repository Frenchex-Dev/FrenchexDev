#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;

/// <summary>
/// </summary>
public class VagrantHaltResponse : BaseVagrantCommandResponse, IVagrantHaltResponse
{
    public VagrantHaltResponse(
        int exitCode
    ) : base(exitCode)
    {
    }
}
