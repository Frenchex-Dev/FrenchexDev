#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;

public class VagrantSshConfigRequest(
    string nameOrId
  , string host
  , bool?  color
  , bool?  machineReadable
  , bool?  version
  , bool?  debug
  , bool?  timestamp
  , bool?  debugTimestamp
  , bool?  noTty
  , bool?  help
) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help)
  , IVagrantSshConfigRequest
{
    public string NameOrId { get; } = nameOrId;
    public string Host     { get; } = host;
}
