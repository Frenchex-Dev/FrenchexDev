using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up;

public interface IUpCommandResponseBuilder : IRootResponseBuilder
{
    IUpCommandResponse Build();

    IUpCommandResponseBuilder WithUpResponse(Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse response);
}