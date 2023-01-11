#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Response;

public class HaltCommandResponse : RootResponse, IHaltCommandResponse
{
    public HaltCommandResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse haltCommandResponse
    )
    {
        Response = haltCommandResponse;
    }

    public Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse Response { get; }
}