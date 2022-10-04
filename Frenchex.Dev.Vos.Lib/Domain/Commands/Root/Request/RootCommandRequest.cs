using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

public class RootRequest : IRootCommandRequest
{
    public RootRequest(IBaseRequest @base)
    {
        Base = @base;
    }

    public IBaseRequest Base { get; }
}