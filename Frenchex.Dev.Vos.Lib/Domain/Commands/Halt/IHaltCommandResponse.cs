using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt;

public interface IHaltCommandResponse : IRootCommandResponse
{
    Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response.IHaltCommandResponse Response { get; }
}