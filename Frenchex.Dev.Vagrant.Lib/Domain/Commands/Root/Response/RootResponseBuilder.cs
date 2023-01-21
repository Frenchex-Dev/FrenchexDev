#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

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