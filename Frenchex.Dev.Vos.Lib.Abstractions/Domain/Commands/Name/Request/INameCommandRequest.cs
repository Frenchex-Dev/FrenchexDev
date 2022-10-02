using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

public interface INameCommandRequest : IRootCommandRequest
{
    string[] Names { get; }
}