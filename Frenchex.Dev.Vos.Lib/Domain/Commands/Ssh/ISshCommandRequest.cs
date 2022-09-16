using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh;

public interface ISshCommandRequest : IRootCommandRequest
{
    string[] NamesOrIds { get; }
    string[] Commands { get; }
    bool Plain { get; }
    string ExtraSshArgs { get; }
}