namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public class RootCommandRequest : IRootCommandRequest
{
    public RootCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}