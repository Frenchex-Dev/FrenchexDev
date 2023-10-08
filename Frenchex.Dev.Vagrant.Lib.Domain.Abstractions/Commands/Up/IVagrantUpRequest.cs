#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Up;

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
