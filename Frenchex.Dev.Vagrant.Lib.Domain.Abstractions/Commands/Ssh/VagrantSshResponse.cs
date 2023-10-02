namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;

public class VagrantSshResponse : IVagrantSshResponse
{
    public VagrantSshResponse(
        int exitCode
    )
    {
        ExitCode = exitCode;
    }

    public int ExitCode { get; }
}
