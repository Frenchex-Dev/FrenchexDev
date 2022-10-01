using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilder : IBaseCommandRequestBuilder
{
    private readonly object _parent;
    private bool? _color;
    private bool? _debug;
    private bool? _help;
    private bool? _machineReadable;
    private string? _packerBinpath;

    private int? _timeoutMs;
    private bool? _version;
    private string? _workingDirectory;

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
            _machineReadable ?? false,
            _version ?? false,
            _debug ?? false,
            _packerBinpath ?? "packer",
            _timeoutMs ?? -1,
            _help ?? false,
            _color ?? false
        );
    }

    public IBaseCommandRequestBuilder UsingTimeoutMs(int timeoutMs)
    {
        _timeoutMs = timeoutMs;
        return this;
    }

    public IBaseCommandRequestBuilder UsingWorkingDirectory(string? workingDirectory)
    {
        _workingDirectory = workingDirectory;
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