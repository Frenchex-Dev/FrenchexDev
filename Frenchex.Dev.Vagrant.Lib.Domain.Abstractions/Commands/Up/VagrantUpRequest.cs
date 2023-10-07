#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

/// <summary>
/// </summary>
public class VagrantUpRequest(
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
) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, tty, help), IVagrantUpRequest
{
    public string   NameOrId        { get; } = nameOrId;
    public bool     Provision       { get; } = provision;
    public string[] ProvisionWith   { get; } = provisionWith;
    public bool     DestroyOnError  { get; } = destroyOnError;
    public bool     Parallel        { get; } = parallel;
    public string   Provider        { get; } = provider;
    public bool     InstallProvider { get; } = installProvider;
}
