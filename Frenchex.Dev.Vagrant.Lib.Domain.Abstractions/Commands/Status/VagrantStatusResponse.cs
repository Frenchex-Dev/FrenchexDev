#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public class VagrantStatusResponse(
    int exitCode
) : IVagrantStatusResponse
{
    public int ExitCode { get; } = exitCode;
}