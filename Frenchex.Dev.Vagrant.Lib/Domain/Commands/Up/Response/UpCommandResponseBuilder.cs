#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Response;

public class UpCommandResponseBuilder : RootResponseBuilder, IUpCommandResponseBuilder
{
    public IUpCommandResponse Build()
    {
        if (null == Process || null == ProcessExecutionResult)
            throw new InvalidOperationException("missing process or execution result");

        return new UpCommandResponse(Process, ProcessExecutionResult);
    }
}