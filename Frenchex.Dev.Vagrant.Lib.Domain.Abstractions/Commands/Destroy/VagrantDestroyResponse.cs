#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;

public class VagrantDestroyResponse(
    int exitCode
) : IVagrantDestroyResponse
{
    public int ExitCode { get; } = exitCode;
}
