using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Response;

public class HaltCommandCommandResponseBuilder : RootCommandResponseBuilder, IHaltCommandCommandResponseBuilder
{
    private Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse? _haltCommandResponse;

    public IHaltCommandResponse Build()
    {
        if (null == _haltCommandResponse)
            throw new InvalidOperationException("Halt command response is null");

        return new HaltCommandResponse(_haltCommandResponse);
    }

    public IHaltCommandCommandResponseBuilder WithHaltResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse response
    )
    {
        _haltCommandResponse = response;
        return this;
    }
}