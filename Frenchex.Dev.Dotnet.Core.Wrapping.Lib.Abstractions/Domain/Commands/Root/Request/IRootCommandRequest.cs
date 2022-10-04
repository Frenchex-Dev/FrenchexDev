using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;

public interface IRootCommandRequest<T> where T : IBaseCommandRequest
{
    T Base { get; }
}