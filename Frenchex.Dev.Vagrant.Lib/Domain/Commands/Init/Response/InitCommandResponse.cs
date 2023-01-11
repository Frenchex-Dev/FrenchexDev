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
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Response;

public class InitCommandResponse : RootResponse, IInitCommandResponse
{
    public InitCommandResponse(
        IProcess process,
        ProcessExecutionResult processExecutionResult
    ) : base(process, processExecutionResult)
    {
    }
}