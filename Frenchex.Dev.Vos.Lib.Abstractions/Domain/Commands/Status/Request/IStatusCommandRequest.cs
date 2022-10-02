using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

public interface IStatusCommandRequest : IRootCommandRequest
{
    string[] Names { get; }
}