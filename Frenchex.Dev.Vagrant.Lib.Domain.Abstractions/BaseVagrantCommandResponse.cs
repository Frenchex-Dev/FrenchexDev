namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
/// </summary>
public abstract class BaseVagrantCommandResponse : IVagrantCommandResponse
{
    protected BaseVagrantCommandResponse(int exitCode)
    {
        ExitCode = exitCode;
    }

    /// <summary>
    /// 
    /// </summary>
    public int ExitCode { get; }
}