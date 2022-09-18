using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up;

public interface IUpCommandResponse : IRootCommandResponse
{
    Vagrant.Lib.Abstractions.Domain.Commands.Up.Response.IUpCommandResponse Response { get; }
}