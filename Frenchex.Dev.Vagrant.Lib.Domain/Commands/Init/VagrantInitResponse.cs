#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

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
