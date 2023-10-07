#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
///     Represents the base interface for Vagrant command requests
/// </summary>
public interface IVagrantCommandRequest
{
    bool Color           { get; }
    bool MachineReadable { get; }
    bool Version         { get; }
    bool Debug           { get; }
    bool Timestamp       { get; }
    bool DebugTimestamp  { get; }
    bool NoTty           { get; }
    bool Help            { get; }
}