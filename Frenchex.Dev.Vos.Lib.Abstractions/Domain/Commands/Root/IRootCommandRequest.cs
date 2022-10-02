namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

public interface IRootCommandRequest
{
    IBaseRequest Base { get; }
}