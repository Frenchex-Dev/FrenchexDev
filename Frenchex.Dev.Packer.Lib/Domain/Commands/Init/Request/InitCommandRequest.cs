using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Request;

public class InitCommandRequest : IFmtCommandRequest
{
    public InitCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}