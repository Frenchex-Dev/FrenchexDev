namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public class BaseCommandRequestBuilder : IBaseCommandRequestBuilder
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

    public IBaseCommandRequest Build()
    {
        if (null == _workingDirectory)
            throw new InvalidOperationException("_workingDirectory is null");

        return new CommandRequestHolder(
            _workingDirectory,
            _tty,
            _timeout,
            _binPath
        );
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