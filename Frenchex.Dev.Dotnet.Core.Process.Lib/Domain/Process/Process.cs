﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.ComponentModel;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib.Domain;
using Microsoft.Extensions.Logging;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

public class Process : IProcess
{
    #region Privates

    private readonly System.Diagnostics.Process _wrappedProcess;
    private readonly IProcessBuildingParameters _processBuildingParameters;
    private readonly ILogger<IProcess> _logger;
    private readonly ITimeSpanTooling _timeSpanTooling;

    #endregion

    #region Publics

    public bool HasStarted { get; private set; }

    public Process(
        System.Diagnostics.Process wrappedProcess,
        IProcessBuildingParameters buildingParameters,
        ILogger<IProcess> logger,
        ITimeSpanTooling timeSpanTooling
    )
    {
        _wrappedProcess = wrappedProcess;
        _processBuildingParameters = buildingParameters;
        _logger = logger;
        _timeSpanTooling = timeSpanTooling;
        HasStarted = false;
    }

    public System.Diagnostics.Process WrappedProcess => _wrappedProcess;

    public ProcessExecutionResult? Result { get; protected set; }


    public void Dispose()
    {
        _logger.LogDebug("Disposing");
        _wrappedProcess.Dispose();
        GC.SuppressFinalize(this);
    }

    public ProcessExecutionResult Start()
    {
        _logger.LogDebug("Starting", _processBuildingParameters);

        Result = new ProcessExecutionResult(_wrappedProcess);

        HasStarted = false;

        try
        {
            HasStarted = _wrappedProcess.Start();
        }
        catch (Exception error)
        {
            // Usually it occurs when an executable file is not found or is not executable

            Result.Completed = true;
            Result.ExitCode = -1;
            Result.Exception = error;

            HasStarted = false;
        }

        ConfigureProcessStreams();

        if (HasStarted)
        {
            // Reads the output stream first and then waits because deadlocks are possible
            if (_processBuildingParameters.RedirectStandardOutput) _wrappedProcess.BeginOutputReadLine();

            if (_processBuildingParameters.RedirectStandardError) _wrappedProcess.BeginErrorReadLine();
        }

        // Creates task to wait for process exit using timeout
        Result.WaitForExitOrTimeOut = Task.Run(() =>
        {
            if (!string.IsNullOrEmpty(_processBuildingParameters.TimeOut))
            {
                var timeout = _timeSpanTooling.ConvertToTimeSpan(_processBuildingParameters.TimeOut);
                bool understood = timeout is not null;
                if (!understood) throw new ArgumentException(nameof(timeout));

                _wrappedProcess.WaitForExit((int)timeout!.Value.TotalMilliseconds);
            }
            else
            {
                _wrappedProcess.WaitForExit();
            }
        });

        if (null == Result.WaitForExitOrTimeOut) throw new ArgumentNullException(nameof(Result.WaitForExitOrTimeOut));

        if (null == Result.OutputCloseEvent) throw new ArgumentNullException(nameof(Result.OutputCloseEvent));

        if (null == Result.ErrorCloseEvent) throw new ArgumentNullException(nameof(Result.ErrorCloseEvent));

        // Create task to wait for process exit and closing all output streams
        Result.WaitForCompleteExit = Task
                .WhenAll(
                    Result.WaitForExitOrTimeOut,
                    Result.OutputCloseEvent.Task,
                    Result.ErrorCloseEvent.Task
                )
                .ContinueWith(_ =>
                {
                    Result.ExitCode = _wrappedProcess.ExitCode;
                    Result.Completed = true;

                    _logger.LogDebug("Complete exit", Result);
                })
            ;

        var timeoutDelayTs = _timeSpanTooling.ConvertToTimeSpan(_processBuildingParameters.TimeOut);

        var listWaitForAny = new List<Task> { Result.WaitForCompleteExit };

        if (timeoutDelayTs is not null) listWaitForAny.Add(Task.Delay((int)timeoutDelayTs.Value.TotalMilliseconds));

        Result.WaitForAny = Task.WhenAny(listWaitForAny);

        return Result;
    }

    public bool TryKillProcess()
    {
        if (null == _wrappedProcess) throw new InvalidOperationException(nameof(_wrappedProcess));
        // caught exceptions are declared in System.Diagnostics.Process metadata
        try
        {
            KillProcess();

            return true;
        }
        catch (Win32Exception e)
        {
            _logger.LogError("TryKillProcess", e);
            return false;
        }
        catch (NotSupportedException e)
        {
            _logger.LogError("TryKillProcess", e);
            return false;
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError("TryKillProcess", e);
            return true;
        }
        catch (Exception e)
        {
            HandleCaughtExceptionWhileKillingProcess(e);

            return false;
        }
    }

    #endregion

    #region Privates

    private void ConfigureProcessStreams()
    {
        if (null == Result) throw new ArgumentNullException(nameof(Result));

        Result.OutputStream = new MemoryStream();

        var outputStreamWriter = new StreamWriter(Result.OutputStream);

        _wrappedProcess.OutputDataReceived += async (_, e) =>
        {
            // The output stream has been closed i.e. the process has terminated
            if (e.Data == null)
            {
                if (null == Result) throw new ArgumentNullException(nameof(Result));

                if (null == Result.OutputCloseEvent) throw new ArgumentNullException(nameof(Result.OutputCloseEvent));

                if (null == Result.ExitedCloseEvent) throw new ArgumentNullException(nameof(Result.ExitedCloseEvent));

                Result.OutputCloseEvent.TrySetResult(true);
                Result.ExitedCloseEvent.TrySetResult(true);

                await outputStreamWriter.FlushAsync();

                return;
            }

            await outputStreamWriter.WriteLineAsync(e.Data);
        };

        _wrappedProcess.ErrorDataReceived += (_, e) =>
        {
            // The error stream has been closed i.e. the process has terminated
            if (e.Data == null)
            {
                if (null == Result) throw new ArgumentNullException(nameof(Result));

                if (null == Result.ErrorCloseEvent) throw new ArgumentNullException(nameof(Result.ErrorCloseEvent));

                if (null == Result.ExitedCloseEvent) throw new ArgumentNullException(nameof(Result.ExitedCloseEvent));

                Result.ErrorCloseEvent.TrySetResult(true);
                Result.ExitedCloseEvent.TrySetResult(true);
            }
        };
    }

    private void KillProcess()
    {
        _wrappedProcess.Kill();
    }

    private static void HandleCaughtExceptionWhileKillingProcess(Exception e)
    {
        throw e;
    }

    public void Stop()
    {
        _wrappedProcess.Kill(true);
    }

    bool IProcess.HasStarted()
    {
        return HasStarted;
    }

    #endregion
}