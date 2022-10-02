using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Request;

public class InitCommandRequest : RootRequest, IInitCommandRequest
{
    public InitCommandRequest(
        IBaseRequest baseRequest,
        string namingPattern,
        int leadingZeroes
    ) : base(baseRequest)
    {
        NamingPattern = namingPattern;
        LeadingZeroes = leadingZeroes;
    }

    public string NamingPattern { get; }
    public int LeadingZeroes { get; }
}