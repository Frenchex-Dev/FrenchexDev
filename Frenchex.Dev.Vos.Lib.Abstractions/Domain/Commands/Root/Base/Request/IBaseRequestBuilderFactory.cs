namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseRequestBuilderFactory
{
    IBaseRequestBuilder Factory(object parent);
}