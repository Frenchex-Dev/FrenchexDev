using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Request;

public class StatusCommandRequest : IStatusCommandRequest
{
    public StatusCommandRequest(IBaseRequest @base, string[] namesOrIds)
    {
        Base = @base;
        Names = namesOrIds;
    }

    public IBaseRequest Base { get; }

    public string[] Names { get; }
}