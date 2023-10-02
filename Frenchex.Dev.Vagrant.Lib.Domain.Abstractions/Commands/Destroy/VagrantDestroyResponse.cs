namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;

public class VagrantDestroyResponse : IVagrantDestroyResponse
{
    public VagrantDestroyResponse(
        int exitCode
    )
    {
        ExitCode = exitCode;
    }

    public int ExitCode { get; }
}
