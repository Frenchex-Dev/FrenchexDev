using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt;

public interface IHaltCommandResponseBuilder : IRootResponseBuilder
{
    IHaltCommandResponse Build();

    IHaltCommandResponseBuilder WithHaltResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse response
    );
}