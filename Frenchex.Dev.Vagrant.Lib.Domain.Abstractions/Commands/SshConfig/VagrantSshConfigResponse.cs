namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;

public class VagrantSshConfigResponse(
    int exitCode
) : IVagrantSshConfigResponse
{
    public int ExitCode { get; } = exitCode;
}
