namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;

public class VagrantSshResponse(
    int exitCode
) : IVagrantSshResponse
{
    public int ExitCode { get; } = exitCode;
}
