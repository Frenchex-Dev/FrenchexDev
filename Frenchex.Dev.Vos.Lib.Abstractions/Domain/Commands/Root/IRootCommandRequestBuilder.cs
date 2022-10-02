namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

public interface IRootCommandRequestBuilder
{
    IBaseRequestBuilder BaseBuilder { get; }
}