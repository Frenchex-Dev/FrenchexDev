using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up;

public class UpCommandResponseBuilder : RootResponseBuilder, IUpCommandResponseBuilder
{
    private Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse? _upCommandResponse;

    public IUpCommandResponse Build()
    {
        if (null == _upCommandResponse) throw new InvalidOperationException("Up command response is null");

        return new UpCommandResponse(_upCommandResponse);
    }

    public IUpCommandResponseBuilder WithUpResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse response
    )
    {
        _upCommandResponse = response;
        return this;
    }
}