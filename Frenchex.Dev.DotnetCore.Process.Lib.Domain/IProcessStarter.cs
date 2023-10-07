#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain;

/// <summary>
/// </summary>
public interface IProcessStarter
{
    /// <summary>
    ///     Starts the process by creating it, calling preparers, starting it and returning an <see cref="IProcessExecution" />
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IProcessExecution> StartAsync(
        IProcessExecutionContext context
      , CancellationToken        cancellationToken = default
    );

    /// <summary>
    ///     Gives developer access to underlying process before starting it
    /// </summary>
    /// <param name="processPreparer"></param>
    void AddProcessPreparer(
        Func<System.Diagnostics.Process, Task> processPreparer
    );
}