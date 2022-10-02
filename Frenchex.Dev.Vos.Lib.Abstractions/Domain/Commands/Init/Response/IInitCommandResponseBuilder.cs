using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;

public interface IInitCommandResponseBuilder : IRootResponseBuilder
{
    IInitCommandResponse Build();
}