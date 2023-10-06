#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision
{
    public class VagrantProvisionResponse(
        int exitCode
    ) : IVagrantProvisionResponse
    {
        public int ExitCode { get; set; } = exitCode;
    }
}
