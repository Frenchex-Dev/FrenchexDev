using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

public interface IUpCommandResponseBuilder : IRootResponseBuilder
{
    IUpCommandResponse Build();

    IUpCommandResponseBuilder WithUpResponse(
        Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse response
    );
}