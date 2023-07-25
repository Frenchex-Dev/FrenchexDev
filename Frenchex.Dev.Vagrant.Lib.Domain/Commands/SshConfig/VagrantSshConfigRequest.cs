#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;

public class VagrantSshConfigRequest : BaseVagrantCommandRequest, IVagrantSshConfigRequest
{
    public VagrantSshConfigRequest(
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
    ) : base(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help)
    {
        NameOrId = nameOrId;
        Host     = host;
    }

    public string NameOrId { get; }
    public string Host     { get; }
}
