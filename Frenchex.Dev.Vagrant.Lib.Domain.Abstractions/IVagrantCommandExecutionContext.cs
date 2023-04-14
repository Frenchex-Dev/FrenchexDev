namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
/// <see cref="IVagrantCommandExecutionContext"/> represents an execution context of a Vagrant binary call.
/// </summary>
public interface IVagrantCommandExecutionContext
{
    /// <summary>
    /// The Vagrantfile.
    /// Defaults to "Vagrantfile"
    /// </summary>
    string? Vagrantfile { get; }

    /// <summary>
    /// Path to where execute vagrant binary
    /// </summary>
    string WorkingDirectory { get; }
}