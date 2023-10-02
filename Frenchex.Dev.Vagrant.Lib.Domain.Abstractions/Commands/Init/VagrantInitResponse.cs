#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;

/// <summary>
/// </summary>
public class VagrantInitResponse : BaseVagrantCommandResponse
{
    public VagrantInitResponse(
        int exitCode
    ) : base(exitCode)
    {
    }
}
