using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root.Request;

public class RootCommandRequest<T> : IRootCommandRequest<T> where T : IBaseCommandRequest
{
    public RootCommandRequest(T @base)
    {
        Base = @base;
    }

    public T Base { get; }
}