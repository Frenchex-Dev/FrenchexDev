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
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponse : RootResponse, IStatusCommandResponse
{
    public StatusCommandResponse(
        IProcess process,
        ProcessExecutionResult processExecutionResult
    ) : base(process, processExecutionResult)
    {
    }
}