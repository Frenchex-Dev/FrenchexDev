#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Response;

public class UpCommandResponse : RootResponse, IUpCommandResponse
{
    public UpCommandResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse upCommandResponse
    )
    {
        Response = upCommandResponse;
    }

    public Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse Response { get; }
}