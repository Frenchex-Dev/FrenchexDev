using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Request;

public class RootCommandRequest : IRootCommandRequest
{
    public RootCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}