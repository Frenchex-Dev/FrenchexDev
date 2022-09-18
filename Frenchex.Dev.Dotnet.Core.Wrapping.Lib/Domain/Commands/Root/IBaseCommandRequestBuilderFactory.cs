namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public interface IBaseCommandRequestBuilderFactory
{
    IBaseCommandRequestBuilder Factory(object parent);
}