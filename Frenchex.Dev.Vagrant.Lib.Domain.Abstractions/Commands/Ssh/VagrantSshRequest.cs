#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Ssh;

public class VagrantSshRequest(
    string nameOrId
  , string extraSshArgs
  , string command
  , bool?  color
  , bool?  machineReadable
  , bool?  version
  , bool?  debug
  , bool?  timestamp
  , bool?  debugTimestamp
  , bool?  noTty
  , bool?  help
) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help), IVagrantSshRequest
{
    public string NameOrId     { get; } = nameOrId;
    public string ExtraSshArgs { get; } = extraSshArgs;
    public string Command      { get; } = command;
}
