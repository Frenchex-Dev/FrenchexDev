#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;

public class VagrantProvisionRequest(
    string   nameOrId
  , string[] provisionWith
  , bool?    color
  , bool?    machineReadable
  , bool?    version
  , bool?    debug
  , bool?    timestamp
  , bool?    debugTimestamp
  , bool?    noTty
  , bool?    help
) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help)
  , IVagrantProvisionRequest
{
    public string   NameOrId      { get; } = nameOrId;
    public string[] ProvisionWith { get; } = provisionWith;
}
