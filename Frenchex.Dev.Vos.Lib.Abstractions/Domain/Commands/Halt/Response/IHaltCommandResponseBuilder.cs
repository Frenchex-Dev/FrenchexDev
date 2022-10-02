using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;

public interface IHaltCommandResponseBuilder : IRootResponseBuilder
{
    IHaltCommandResponse Build();

    IHaltCommandResponseBuilder WithHaltResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse response
    );
}