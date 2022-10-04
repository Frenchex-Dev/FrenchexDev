using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;
using IUpCommandResponse = Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Response;

public class UpCommandResponseBuilder : RootResponseBuilder, IUpCommandResponseBuilder
{
    private IUpCommandResponse? _upCommandResponse;

    public Abstractions.Domain.Commands.Up.Response.IUpCommandResponse Build()
    {
        if (null == _upCommandResponse) throw new InvalidOperationException("Up command response is null");

        return new UpCommandResponse(_upCommandResponse);
    }

    public IUpCommandResponseBuilder WithUpResponse(
        IUpCommandResponse response
    )
    {
        _upCommandResponse = response;
        return this;
    }
}