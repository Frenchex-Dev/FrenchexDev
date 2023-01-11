#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Response;

public class InitCommandResponseBuilder : RootResponseBuilder, IInitCommandResponseBuilder
{
    public IInitCommandResponse Build()
    {
        if (null == Process) throw new InvalidOperationException("process is null");

        if (null == ProcessExecutionResult) throw new InvalidOperationException("processExecutionResult is null");

        return new InitCommandResponse(Process, ProcessExecutionResult);
    }
}