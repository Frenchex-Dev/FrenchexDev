using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

public interface INameCommandResponse : IRootCommandResponse
{
    string[] Names { get; }
}