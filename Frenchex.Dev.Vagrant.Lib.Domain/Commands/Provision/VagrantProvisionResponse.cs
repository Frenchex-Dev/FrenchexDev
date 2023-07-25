namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public class VagrantProvisionResponse : IVagrantProvisionResponse
{
    public VagrantProvisionResponse(int exitCode)
    {
        ExitCode = exitCode;
    }

    public int ExitCode { get; set; }
}
