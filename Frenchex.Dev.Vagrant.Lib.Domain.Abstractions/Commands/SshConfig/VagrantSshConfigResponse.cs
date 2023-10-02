namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;

public class VagrantSshConfigResponse : IVagrantSshConfigResponse
{
    public VagrantSshConfigResponse(
        int exitCode
    )
    {
        ExitCode = exitCode;
    }

    public int ExitCode { get; }
}
