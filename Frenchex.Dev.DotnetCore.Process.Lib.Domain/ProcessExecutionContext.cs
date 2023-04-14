namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain;

public class ProcessExecutionContext : IProcessExecutionContext
{
    private readonly List<Func<string, Task>> _stdOutListeners;
    private readonly List<Func<string, Task>> _stdErrListeners;

    public ProcessExecutionContext(
        string path,
        string binary,
        string[] arguments,
        Dictionary<string, string> environment,
        bool saveStdOutStream, 
        bool saveStdErrStream
    )
    {
        WorkingDirectory = path;
        Binary = binary;
        Arguments = arguments;
        Environment = environment;
        SaveStdOutStream = saveStdOutStream;
        SaveStdErrStream = saveStdErrStream;
        _stdOutListeners = new List<Func<string, Task>>();
        _stdErrListeners = new List<Func<string, Task>>();
    }

    public string WorkingDirectory { get; }
    public string Binary { get; }
    public string[] Arguments { get; }
    public Dictionary<string, string> Environment { get; }
    public IProcessExecutionContext AddStdOutListener(Func<string, Task> listener)
    {
        _stdOutListeners.Add(listener);
        return this;
    }

    public List<Func<string, Task>> GetStdOutListeners()
    {
        return _stdOutListeners;
    }

    public IProcessExecutionContext AddStdErrListener(Func<string, Task> listener)
    {
        _stdErrListeners.Add(listener);
        return this;
    }

    public List<Func<string, Task>> GetStdErrListeners()
    {
        return _stdErrListeners;
    }

    public bool SaveStdOutStream { get;  }
    public bool SaveStdErrStream { get;  }
    public IProcessExecutionContext SetInputStreamHandler(Func<Task<string>> inputStreamHandler)
    {
        throw new NotImplementedException();
    }
}