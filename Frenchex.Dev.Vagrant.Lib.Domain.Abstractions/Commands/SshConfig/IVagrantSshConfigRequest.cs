#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig
{
    public interface IVagrantSshConfigRequest : IVagrantCommandRequest
    {
        string Host     { get; }
        string NameOrId { get; }
    }
}
