﻿namespace Frenchex.Dev.DotnetCore.Process.Lib.Domain;

/// <summary>
///     Implementation of <see cref="IProcessExecution" /> using an internal <see cref="System.Diagnostics.Process" /> to
///     handle
///     the process lifecycle.
/// </summary>
public sealed class ProcessExecution : IProcessExecution
{
    #region Privates

    /// <summary>
    ///     The internally wrapped <see cref="System.Diagnostics.Process" />.
    /// </summary>
    private readonly System.Diagnostics.Process _internalProcess;

    #endregion

    #region Constructors

    /// <summary>
    ///     Public constructor
    /// </summary>
    /// <param name="internalProcess"></param>
    /// <param name="hasStarted"></param>
    /// <param name="tscFinished"></param>
    public ProcessExecution(
        System.Diagnostics.Process internalProcess
      , bool                       hasStarted
    )
    {
        _internalProcess = internalProcess;
        HasStarted       = hasStarted;
    }

    #endregion

    #region Public API

    /// <summary>
    ///     Interface: <inheritdoc />
    ///     <para>
    ///         Implementation: Returns if the <see cref="_internalProcess" /> has started.
    ///     </para>
    /// </summary>
    public bool HasStarted { get; }

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Returns if the <see cref="_internalProcess" /> has completely exited.
    ///     </para>
    /// </summary>
    public bool HasExited => _internalProcess.HasExited;

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Returns the <see cref="_internalProcess" /> Exit code if set.
    ///     </para>
    /// </summary>
    public int ExitCode => _internalProcess.ExitCode;

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Returns the <see cref="StreamReader" /> of the StandardOutput of the
    ///         <see cref="_internalProcess" />.
    ///     </para>
    /// </summary>
    public StreamReader? StdOutStream => _internalProcess.StandardOutput;

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Returns the <see cref="StreamReader" /> of the StandardError of the
    ///         <see cref="_internalProcess" />
    ///     </para>
    /// </summary>
    public StreamReader? StdErrStream => _internalProcess.StandardError;

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Returns the <see cref="StreamWriter" /> of the StandardInput of the
    ///         <see cref="_internalProcess" />
    ///     </para>
    /// </summary>
    public StreamWriter? StdInStream => _internalProcess.StandardInput;

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Stops the <see cref="_internalProcess" /> asynchronously within given timeout ot cancellation
    ///         requested.
    ///     </para>
    /// </summary>
    /// <param name="timeOut"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task StopAsync(
        TimeSpan          timeOut
      , CancellationToken cancellationToken = default
    )
    {
        await StopAsync((int)timeOut.TotalMilliseconds, cancellationToken);
    }

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Stops the <see cref="_internalProcess" /> asynchronously within given timeout ot cancellation
    ///         requested.
    ///     </para>
    /// </summary>
    /// <param name="timeOutMs">Timeout in milliseconds</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task StopAsync(
        int               timeOutMs
      , CancellationToken cancellationToken = default
    )
    {
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(timeOutMs);

        var jointSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        await _internalProcess.WaitForExitAsync(jointSource.Token);
    }

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Kills the <see cref="_internalProcess" />
    ///     </para>
    /// </summary>
    public void Kill(
        bool entireProcessTree
    )
    {
        _internalProcess.Kill(entireProcessTree);
    }

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation : Kills the <see cref="_internalProcess" /> wrapped in a try/catch
    ///     </para>
    /// </summary>
    public void TryKill(
        bool entireProcessTree
    )
    {
        try
        {
            _internalProcess.Kill(entireProcessTree);
        }
        catch
        {
        }
    }

    /// <summary>
    ///     Interface : <inheritdoc />
    ///     <para>
    ///         Implementation: awaits for WaitForExitAsync() on <see cref="_internalProcess" />
    ///     </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task WaitForExitAsync(
        CancellationToken cancellationToken = default
    )
    {
        await _internalProcess.WaitForExitAsync(cancellationToken);
    }

    /// <summary>
    ///     Same as <see cref="StopAsync(System.TimeSpan,System.Threading.CancellationToken)" />
    /// </summary>
    /// <param name="timeoutMs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task WaitForExitAsync(
        int               timeoutMs
      , CancellationToken cancellationToken = default
    )
    {
        await StopAsync(timeoutMs, cancellationToken);
    }

    /// <summary>
    ///     Same as <see cref="StopAsync(System.TimeSpan,System.Threading.CancellationToken)" />
    /// </summary>
    /// <param name="timeout"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task WaitForExitAsync(
        TimeSpan          timeout
      , CancellationToken cancellationToken = default
    )
    {
        await StopAsync(timeout, cancellationToken);
    }

    #endregion
}