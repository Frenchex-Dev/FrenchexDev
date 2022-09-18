using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up;

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