#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;

/// <summary>
///     Represents a process execution context.
/// </summary>
public interface IProcessExecutionContext
{
    /// <summary>
    ///     Represents the working directory for the process to start
    /// </summary>
    string WorkingDirectory { get; }

    /// <summary>
    ///     Represents the binary for the process to start
    /// </summary>
    string Binary { get; }

    /// <summary>
    ///     Represents the arguments for the process to start
    /// </summary>
    string Arguments { get; }

    /// <summary>
    ///     Represents CreateNoWindow for the process to start
    /// </summary>
    bool CreateNoWindow { get; }

    /// <summary>
    ///     Represents UseShellExecute for the process to start
    /// </summary>
    bool UseShellExecute { get; }

    /// <summary>
    ///     Add listeners to StandardOutput data
    /// </summary>
    /// <param name="listener"></param>
    /// <returns></returns>
    IProcessExecutionContext AddStdOutListener(
        Func<string, Task> listener
    );

    /// <summary>
    ///     Get listeners of StandardOutput data
    /// </summary>
    /// <returns></returns>
    List<Func<string, Task>> GetStdOutListeners();

    /// <summary>
    ///     Add listeners to StandardError data
    /// </summary>
    /// <param name="listener"></param>
    /// <returns></returns>
    IProcessExecutionContext AddStdErrListener(
        Func<string, Task> listener
    );

    /// <summary>
    ///     Get listeners for StandardError data
    /// </summary>
    /// <returns></returns>
    List<Func<string, Task>> GetStdErrListeners();

    /// <summary>
    ///     Sets the input stream handler
    /// </summary>
    /// <param name="inputStreamHandler"></param>
    /// <returns></returns>
    IProcessExecutionContext SetInputStreamHandler(
        Func<Task<string>> inputStreamHandler
    );
}
