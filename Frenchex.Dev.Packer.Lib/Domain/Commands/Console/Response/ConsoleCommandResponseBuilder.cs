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
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Response;

public class ConsoleCommandResponseBuilder : IConsoleCommandResponseBuilder
{
    public IRootCommandResponseBuilder SetProcess(IProcess process)
    {
        throw new NotImplementedException();
    }

    public IRootCommandResponseBuilder SetProcessExecutionResult(ProcessExecutionResult processExecutionResult)
    {
        throw new NotImplementedException();
    }

    public IConsoleCommandResponse Build()
    {
        throw new NotImplementedException();
    }
}