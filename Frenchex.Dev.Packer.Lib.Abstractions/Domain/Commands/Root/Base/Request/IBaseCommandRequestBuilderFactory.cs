namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequestBuilderFactory
{
    IBaseCommandRequestBuilder Factory(object parent);
}