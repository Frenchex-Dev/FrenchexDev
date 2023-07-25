#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

/// <summary>
/// </summary>
public class VagrantUpRequest : BaseVagrantCommandRequest, IVagrantUpRequest
{
    public VagrantUpRequest(
        string   nameOrId
      , bool     provision
      , string[] provisionWith
      , bool     destroyOnError
      , bool     parallel
      , string   provider
      , bool     installProvider
      , bool?    color
      , bool?    machineReadable
      , bool?    version
      , bool?    debug
      , bool?    timestamp
      , bool?    debugTimestamp
      , bool?    tty
      , bool?    help
    ) : base(color, machineReadable, version, debug, timestamp, debugTimestamp, tty, help)
    {
        NameOrId        = nameOrId;
        Provision       = provision;
        ProvisionWith   = provisionWith;
        DestroyOnError  = destroyOnError;
        Parallel        = parallel;
        Provider        = provider;
        InstallProvider = installProvider;
    }

    public string   NameOrId        { get; }
    public bool     Provision       { get; }
    public string[] ProvisionWith   { get; }
    public bool     DestroyOnError  { get; }
    public bool     Parallel        { get; }
    public string   Provider        { get; }
    public bool     InstallProvider { get; }
}
