#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

public interface IVagrantUpRequest : IVagrantCommandRequest
{
    string   NameOrId        { get; }
    bool     Provision       { get; }
    string[] ProvisionWith   { get; }
    bool     DestroyOnError  { get; }
    bool     Parallel        { get; }
    string   Provider        { get; }
    bool     InstallProvider { get; }
}