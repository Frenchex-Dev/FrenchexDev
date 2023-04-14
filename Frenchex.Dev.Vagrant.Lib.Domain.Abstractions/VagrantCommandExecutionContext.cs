namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
/// <para>
/// Implements <see cref="IVagrantCommandExecutionContext"/>
/// </para>
/// <inheritdoc cref="IVagrantCommandExecutionContext"/>
/// </summary>
public class VagrantCommandExecutionContext : IVagrantCommandExecutionContext
{
    /// <summary>
    /// 
    /// </summary>
    public string? Vagrantfile { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public required string WorkingDirectory { get; set; }
}