using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilder<T> : IBaseCommandRequestBuilder<IBaseCommandRequest>
    where T : class, IBaseCommandRequest, new()
{
    private readonly object _parent;
    private string? _binPath;

    private bool? _tty;
    private string? _workingDirectory;
    private string? _timeout;


    public BaseCommandRequestBuilder(object parent)
    {
        _parent = parent;
    }

    public T Build()
    {
        if (null == _workingDirectory)
            throw new InvalidOperationException("_workingDirectory is null");

        return Activator.CreateInstance<T>()
        return new T(
            _workingDirectory,
            _tty,
            _timeout,
            _binPath
        );
    }

    public T Parent<T, R, V>() where T : class, IRootCommandRequestBuilder<R, V>
        where R : class, IBaseCommandRequestBuilder<V>
        where V : class, IBaseCommandRequest
    {
        return (T) _parent;
    }


    IBaseCommandRequest IBaseCommandRequestBuilder<IBaseCommandRequest>.UsingWorkingDirectory(string? workingDirectory)
    {
        throw new NotImplementedException();
    }

    IBaseCommandRequest IBaseCommandRequestBuilder<IBaseCommandRequest>.UsingTimeout(string timeout)
    {
        _timeout = timeout;
        return this;
    }

    IBaseCommandRequest IBaseCommandRequestBuilder<IBaseCommandRequest>.UsingBinPath(string binPath)
    {
        throw new NotImplementedException();
    }

    public IBaseCommandRequestBuilder UsingTimeout(string timeout)
    {
        _timeout = timeout;
        return this;
    }

    public IBaseCommandRequestBuilder UsingWorkingDirectory(string? workingDirectory)
    {
        _workingDirectory = workingDirectory;
        return this;
    }

    public IBaseCommandRequestBuilder UsingBinPath(string binPath)
    {
        _binPath = binPath;
        return this;
    }

    public T Parent<T>() where T : IRootCommandRequestBuilder
    {
        return (T) _parent;
    }

    public IBaseCommandRequestBuilder WithTty(bool with)
    {
        _tty = with;
        return this;
    }
}