using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Request;

public class InitCommandCommandRequest : RootCommandRequest, IInitCommandRequest
{
    public InitCommandCommandRequest(
        IBaseCommandRequest baseCommandRequest,
        string namingPattern,
        int leadingZeroes
    ) : base(baseCommandRequest)
    {
        NamingPattern = namingPattern;
        LeadingZeroes = leadingZeroes;
    }

    public string NamingPattern { get; }
    public int LeadingZeroes { get; }
}