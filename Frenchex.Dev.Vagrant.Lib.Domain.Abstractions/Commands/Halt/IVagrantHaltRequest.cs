#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt
{
    public interface IVagrantHaltRequest : IVagrantCommandRequest
    {
        string? NameOrId { get; }
        bool    Force    { get; }
    }
}
