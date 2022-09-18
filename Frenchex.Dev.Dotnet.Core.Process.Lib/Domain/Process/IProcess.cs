namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

public interface IProcess : IDisposable
{
    public System.Diagnostics.Process WrappedProcess { get; }
    ProcessExecutionResult Start();
    void Stop();
    bool HasStarted();
}