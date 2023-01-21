#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponseBuilder : RootResponseBuilder, IStatusCommandResponseBuilder
{
    public IStatusCommandResponse Build()
    {
        if (null == Process || null == ProcessExecutionResult)
            throw new InvalidOperationException("process or processexecutionresult is null");

        return new StatusCommandResponse(
            Process,
            ProcessExecutionResult
        );
    }
}