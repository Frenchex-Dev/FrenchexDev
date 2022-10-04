using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

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