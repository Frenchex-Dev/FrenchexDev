using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

public interface IRootCommandRequestBuilder
{
    IBaseRequestBuilder BaseBuilder { get; }
}