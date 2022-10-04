using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Response;

public class UpCommandCommandResponseBuilder : RootCommandResponseBuilder, IUpCommandCommandResponseBuilder
{
    private Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse? _upCommandResponse;

    public IUpCommandResponse Build()
    {
        if (null == _upCommandResponse) throw new InvalidOperationException("Up command response is null");

        return new UpCommandResponse(_upCommandResponse);
    }

    public IUpCommandCommandResponseBuilder WithUpResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse response
    )
    {
        _upCommandResponse = response;
        return this;
    }
}