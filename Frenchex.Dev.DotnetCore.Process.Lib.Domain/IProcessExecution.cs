#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain;

/// <summary>
///     Represents a process execution started using <see cref="IProcessStarter" />
/// </summary>
public interface IProcessExecution
{
    /// <summary>
    ///     Returns if the process has been started
    /// </summary>
    bool HasStarted { get; }

    /// <summary>
    ///     Returns if the process has exited.
    /// </summary>
    bool HasExited { get; }

    /// <summary>
    ///     Returns the exit code of the process
    /// </summary>
    int ExitCode { get; }

    /// <summary>
    ///     Returns the StandardOutput of the process
    /// </summary>
    StreamReader StdOutStream { get; }

    /// <summary>
    ///     Returns the StandardError of the process
    /// </summary>
    StreamReader StdErrStream { get; }

    /// <summary>
    ///     Returns the StandardInput of the process
    /// </summary>
    StreamWriter StdInStream { get; }

    /// <summary>
    ///     Stops the process asynchronously within given timeout or cancellation requested
    /// </summary>
    /// <param name="timeOut"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    ///     <see cref="Task" />
    /// </returns>
    Task StopAsync(
        TimeSpan          timeOut
      , CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Stops the process asynchronously within given timeout in milliseconds or cancellation requested
    /// </summary>
    /// <param name="timeOutMs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    ///     <see cref="Task" />
    /// </returns>
    Task StopAsync(
        int               timeOutMs
      , CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Kills the process
    /// </summary>
    /// <param name="entireProcessTree"></param>
    void Kill(
        bool entireProcessTree
    );

    /// <summary>
    ///     Kills the process
    /// </summary>
    /// <param name="allTree"></param>
    void TryKill(
        bool allTree
    );

    /// <summary>
    ///     Waits for the process to exit or cancellation requested
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task WaitForExitAsync(
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Waits for the process to exit within timeoutMs or cancellation requested
    /// </summary>
    /// <param name="timeoutMs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task WaitForExitAsync(
        int               timeoutMs
      , CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Waits for the process to exit within timeout or cancellation requested
    /// </summary>
    /// <param name="timeout"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task WaitForExitAsync(
        TimeSpan          timeout
      , CancellationToken cancellationToken = default
    );
}
