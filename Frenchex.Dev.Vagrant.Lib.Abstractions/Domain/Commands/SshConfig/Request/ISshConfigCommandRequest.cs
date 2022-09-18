using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request
{
    public interface ISshConfigCommandRequest : IRootCommandRequest
    {
        string NameOrId { get; }
        string Host { get; }
    }
}