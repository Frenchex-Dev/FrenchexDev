using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Request;

public class FmtCommandRequest : IFmtCommandRequest
{
    public FmtCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}