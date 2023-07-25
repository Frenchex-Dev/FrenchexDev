namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

/// <summary>
///     Represents the basic common options for all vagrant command requests
/// </summary>
public abstract class BaseVagrantCommandRequest : IVagrantCommandRequest
{
    protected BaseVagrantCommandRequest(
        bool? color
      , bool? machineReadable
      , bool? version
      , bool? debug
      , bool? timestamp
      , bool? debugTimestamp
      , bool? noTty
      , bool? help
    )
    {
        Color           = color           ?? false;
        MachineReadable = machineReadable ?? false;
        Version         = version         ?? false;
        Debug           = debug           ?? false;
        Timestamp       = timestamp       ?? false;
        DebugTimestamp  = debugTimestamp  ?? false;
        NoTty           = noTty           ?? false;
        Help            = help            ?? false;
    }

    public bool NoTty           { get; }
    public bool Color           { get; }
    public bool MachineReadable { get; }
    public bool Version         { get; }
    public bool Debug           { get; }
    public bool Timestamp       { get; }
    public bool DebugTimestamp  { get; }
    public bool Help            { get; }
}
