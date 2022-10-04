namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequestBuilderFactory<out T, TR>
    where T : IBaseCommandRequestBuilder<TR> 
    where TR : IBaseCommandRequest
{
    T Factory(object parent);
}