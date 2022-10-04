using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequestBuilder<out T>
    where T : class, IBaseCommandRequest
{
    T Build();

    T Parent<T, R, V>()
        where T : class, IRootCommandRequestBuilder<R, V>
        where R : class, IBaseCommandRequestBuilder<V>
        where V : class, IBaseCommandRequest;

    T UsingWorkingDirectory(string? workingDirectory);
    T UsingTimeout(string timeout);
    T UsingBinPath(string binPath);
}