﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

public class ProcessExecutionResult
{
    public ProcessExecutionResult(System.Diagnostics.Process process)
    {
        Process = process;
    }

    public bool? Completed { get; set; }
    public int? ExitCode { get; set; }
    public Exception? Exception { get; set; }
    public TaskCompletionSource<bool>? OutputCloseEvent { get; } = new();
    public TaskCompletionSource<bool>? ErrorCloseEvent { get; } = new();
    public TaskCompletionSource<bool>? ExitedCloseEvent { get; } = new();
    public Task? WaitForExitOrTimeOut { get; set; }
    public Task? WaitForCompleteExit { get; set; }
    public Task<Task>? WaitForAny { get; set; }
    public System.Diagnostics.Process Process { get; }
    public MemoryStream? OutputStream { get; set; }
}