using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

public interface ISshConfigCommandRequest : IRootCommandRequest
{
    string[] NamesOrIds { get; }
    string Host { get; }
}