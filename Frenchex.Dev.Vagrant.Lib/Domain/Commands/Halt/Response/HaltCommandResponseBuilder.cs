#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Response;

public class HaltCommandResponseBuilder : RootResponseBuilder, IHaltCommandResponseBuilder
{
    public IHaltCommandResponse Build()
    {
        if (null == Process || null == ProcessExecutionResult)
            throw new InvalidOperationException("process or execution result is null");

        return new HaltCommandResponse(Process, ProcessExecutionResult);
    }
}