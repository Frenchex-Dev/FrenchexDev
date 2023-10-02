namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public class VagrantStatusResponse : IVagrantStatusResponse
{
    public VagrantStatusResponse(
        int exitCode
    )
    {
        ExitCode = exitCode;
    }

    public int ExitCode { get; }
}
