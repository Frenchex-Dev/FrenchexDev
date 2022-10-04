using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;
using IHaltCommandResponse = Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Response;

public class HaltCommandResponseBuilder : RootResponseBuilder, IHaltCommandResponseBuilder
{
    private IHaltCommandResponse? _haltCommandResponse;

    public Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse Build()
    {
        if (null == _haltCommandResponse)
            throw new InvalidOperationException("Halt command response is null");

        return new HaltCommandResponse(_haltCommandResponse);
    }

    public IHaltCommandResponseBuilder WithHaltResponse(
        IHaltCommandResponse response
    )
    {
        _haltCommandResponse = response;
        return this;
    }
}