#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
/// </summary>
public abstract class BaseVagrantCommandResponse(
    int exitCode
) : IVagrantCommandResponse
{
    /// <summary>
    /// </summary>
    public int ExitCode { get; } = exitCode;
}
