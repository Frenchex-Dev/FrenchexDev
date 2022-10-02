using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;

public interface IHaltCommandResponse : IRootCommandResponse
{
    Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse Response { get; }
}