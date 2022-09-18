using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;

public interface ISshCommandRequest : IRootCommandRequest
{
    string NameOrId { get; }
    string Command { get; }
    bool Plain { get; }
    string ExtraSshArgs { get; }
    bool WithColor { get; }
}