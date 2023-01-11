#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

#endregion

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public class RootResponse : IRootCommandResponse
{
    public RootResponse(IProcess process, ProcessExecutionResult processExecutionResult)
    {
        Process = process;
        ProcessExecutionResult = processExecutionResult;
    }

    public IProcess Process { get; }

    public ProcessExecutionResult ProcessExecutionResult { get; }
}