#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

#endregion

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public abstract class RootResponseBuilder : IRootCommandResponseBuilder
{
    protected IProcess? Process;
    protected ProcessExecutionResult? ProcessExecutionResult;

    public IRootCommandResponseBuilder SetProcess(IProcess process)
    {
        Process = process;
        return this;
    }

    public IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult)
    {
        ProcessExecutionResult = processExecutionResult;
        return this;
    }
}