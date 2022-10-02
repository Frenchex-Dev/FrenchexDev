using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

public interface ISshCommandRequest : IRootCommandRequest
{
    string[] NamesOrIds { get; }
    string[] Commands { get; }
    bool Plain { get; }
    string ExtraSshArgs { get; }
}