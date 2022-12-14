using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Request;

public class NameCommandCommandRequest : RootCommandRequest, INameCommandRequest
{
    public NameCommandCommandRequest(
        IBaseCommandRequest baseCommand,
        string[] names
    ) : base(baseCommand)
    {
        Names = names;
    }

    public string[] Names { get; }
}