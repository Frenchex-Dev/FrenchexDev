namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
///     <see cref="IVagrantCommandExecutionContext" /> represents an execution context of a Vagrant binary call.
/// </summary>
public interface IVagrantCommandExecutionContext
{
    /// <summary>
    ///     Path to where execute vagrant binary
    /// </summary>
    string WorkingDirectory { get; }

    /// <summary>
    /// </summary>
    string VagrantBin { get; }

    /// <summary>
    /// </summary>
    string Vagrantfile { get; }

    /// <summary>
    /// </summary>
    Dictionary<string, string> Environment { get; }

    /// <summary>
    /// </summary>
    bool SaveStdOutStream { get; }

    /// <summary>
    /// </summary>
    bool SaveStdErrStream { get; }

    /// <summary>
    /// </summary>
    string? Timeout { get; }
}
