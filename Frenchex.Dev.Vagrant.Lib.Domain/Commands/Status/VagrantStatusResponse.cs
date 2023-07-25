namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

public class VagrantStatusResponse : IVagrantStatusResponse
{
    public int ExitCode { get; }
}
