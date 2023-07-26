namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

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
