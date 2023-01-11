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

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Response;

public interface IRootCommandResponseBuilder
{
    IRootCommandResponseBuilder SetProcess(IProcess process);
    IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult);
}