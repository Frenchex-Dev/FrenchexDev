using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilder : IBaseCommandRequestBuilder
{
    private readonly object _parent;
    private bool? _color;
    private bool? _debug;
    private bool? _help;
    private bool? _machineReadable;
    private string? _packerBinpath;

    private string? _timeout;
    private bool? _version;
    private string? _workingDirectory;
    private bool? _timeStamp;
    private bool? _debugTimestamp;
    private bool? _tty;

    public BaseCommandRequestBuilder(object parent)
    {
        _parent = parent;
    }

    public IBaseCommandRequest Build()
    {
        if (null == _workingDirectory)
            throw new InvalidOperationException("_workingDirectory is null");

        return new BaseCommandRequest(
            _workingDirectory,
            _timeStamp ?? false,
            _debugTimestamp ?? false,
            _timeout,
            _machineReadable ?? false,
            _version ?? false,
            _debug ?? false,
            _packerBinpath ?? "packer",
            _help ?? false,
            _color ?? false
        );
    }

    T IBaseCommandRequestBuilder.Parent<T>()
    {
        return (T) _parent;
    }

    public IBaseCommandRequestBuilder UsingTimeoutTs(string timeout)
    {
        _timeout = timeout;
        return this;
    }

    public IBaseCommandRequestBuilder UsingWorkingDirectory(string? workingDirectory)
    {
        _workingDirectory = workingDirectory;
        return this;
    }

    public IBaseCommandRequestBuilder UsingTimeout(string timeout)
    {
        _timeout = timeout;
        return this;
    }

    public T Parent<T>() where T : IRootCommandRequestBuilder
    {
        return (T) _parent;
    }

    public IBaseCommandRequestBuilder UsingBinPath(string packerBinPath)
    {
        _packerBinpath = packerBinPath;
        return this;
    }

    public IBaseCommandRequestBuilder WithColor(bool with)
    {
        _color = with;
        return this;
    }

    public IBaseCommandRequestBuilder WithDebug(bool with)
    {
        _debug = with;
        return this;
    }

    public IBaseCommandRequestBuilder WithTimestamp(bool with)
    {
        _timeStamp = with;
        return this;
    }

    public IBaseCommandRequestBuilder WithDebugTimestamp(bool with)
    {
        _debugTimestamp = with;
        return this;
    }

    public IBaseCommandRequestBuilder WithTty(bool with)
    {
        _tty = with;
        return this;
    }

    public IBaseCommandRequestBuilder WithHelp(bool with)
    {
        _help = with;
        return this;
    }

    public IBaseCommandRequestBuilder WithMachineReadable(bool with)
    {
        _machineReadable = with;
        return this;
    }

    public IBaseCommandRequestBuilder WithVersion(bool with)
    {
        _version = with;
        return this;
    }
}