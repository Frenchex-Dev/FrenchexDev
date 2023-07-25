namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
///     <para>
///         Implements <see cref="IVagrantCommandExecutionContext" />
///     </para>
///     <inheritdoc cref="IVagrantCommandExecutionContext" />
/// </summary>
public class VagrantCommandExecutionContext : IVagrantCommandExecutionContext
{
    /// <summary>
    /// </summary>
    public string Vagrantfile { get; set; } = "Vagrantfile";

    /// <summary>
    /// </summary>
    public Dictionary<string, string> Environment { get; } = new();

    /// <summary>
    /// </summary>
    public bool SaveStdOutStream { get; set; }

    /// <summary>
    /// </summary>
    public bool SaveStdErrStream { get; set; }

    /// <summary>
    /// </summary>
    public string? Timeout { get; set; }

    /// <summary>
    /// </summary>
    public required string WorkingDirectory { get; set; }

    /// <summary>
    /// </summary>
    public string VagrantBin { get; set; } = "vagrant";
}
