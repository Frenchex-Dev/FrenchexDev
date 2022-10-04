using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;

public interface IRootCommandRequestBuilder<out T, TR> 
    where T : IBaseCommandRequestBuilder<TR> 
    where TR : IBaseCommandRequest
{
    T BaseBuilder { get; }
}