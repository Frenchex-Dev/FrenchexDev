#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions
{
    /// <summary>
    ///     Represents the basic common options for all vagrant command requests
    /// </summary>
    public abstract class BaseVagrantCommandRequest(
        bool? color
      , bool? machineReadable
      , bool? version
      , bool? debug
      , bool? timestamp
      , bool? debugTimestamp
      , bool? noTty
      , bool? help
    ) : IVagrantCommandRequest
    {
        public bool NoTty           { get; } = noTty           ?? false;
        public bool Color           { get; } = color           ?? false;
        public bool MachineReadable { get; } = machineReadable ?? false;
        public bool Version         { get; } = version         ?? false;
        public bool Debug           { get; } = debug           ?? false;
        public bool Timestamp       { get; } = timestamp       ?? false;
        public bool DebugTimestamp  { get; } = debugTimestamp  ?? false;
        public bool Help            { get; } = help            ?? false;
    }
}
