#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain
{
    public class ProcessExecutionContext(
        string                     path
      , string                     binary
      , string                     arguments
      , Dictionary<string, string> environment
      , bool                       saveStdOutStream
      , bool                       saveStdErrStream
    ) : IProcessExecutionContext
    {
        private readonly List<Func<string, Task>> _stdErrListeners = new();
        private readonly List<Func<string, Task>> _stdOutListeners = new();

        public bool SaveStdOutStream { get; } = saveStdOutStream;
        public bool SaveStdErrStream { get; } = saveStdErrStream;

        public string                     WorkingDirectory { get; } = path;
        public string                     Binary           { get; } = binary;
        public string                     Arguments        { get; } = arguments;
        public Dictionary<string, string> Environment      { get; } = environment;

        public IProcessExecutionContext AddStdOutListener(
            Func<string, Task> listener
        )
        {
            _stdOutListeners.Add(listener);
            return this;
        }

        public List<Func<string, Task>> GetStdOutListeners()
        {
            return _stdOutListeners;
        }

        public IProcessExecutionContext AddStdErrListener(
            Func<string, Task> listener
        )
        {
            _stdErrListeners.Add(listener);
            return this;
        }

        public List<Func<string, Task>> GetStdErrListeners()
        {
            return _stdErrListeners;
        }

        public IProcessExecutionContext SetInputStreamHandler(
            Func<Task<string>> inputStreamHandler
        )
        {
            throw new NotImplementedException();
        }
    }
}
