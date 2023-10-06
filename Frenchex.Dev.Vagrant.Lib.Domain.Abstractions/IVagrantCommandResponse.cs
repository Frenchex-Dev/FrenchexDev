#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions
{
    /// <summary>
    ///     Represents the base interface for Vagrant command responses
    /// </summary>
    public interface IVagrantCommandResponse
    {
        int ExitCode { get; }
    }
}
