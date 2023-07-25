#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public class VagrantProvisionRequest : BaseVagrantCommandRequest, IVagrantProvisionRequest
{
    public VagrantProvisionRequest(
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
    ) : base(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help)
    {
        NameOrId      = nameOrId;
        ProvisionWith = provisionWith;
    }

    public string   NameOrId      { get; }
    public string[] ProvisionWith { get; }
}
