using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Request;

public class NameCommandRequest : RootRequest, INameCommandRequest
{
    public NameCommandRequest(
        IBaseRequest @base,
        string[] names
    ) : base(@base)
    {
        Names = names;
    }

    public string[] Names { get; }
}