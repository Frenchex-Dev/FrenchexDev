#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public class VagrantSshRequest : BaseVagrantCommandRequest, IVagrantSshRequest
{
    public VagrantSshRequest(
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
    ) : base(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help)
    {
        NameOrId     = nameOrId;
        ExtraSshArgs = extraSshArgs;
        Command      = command;
    }

    public string NameOrId     { get; }
    public string ExtraSshArgs { get; }
    public string Command      { get; }
}
