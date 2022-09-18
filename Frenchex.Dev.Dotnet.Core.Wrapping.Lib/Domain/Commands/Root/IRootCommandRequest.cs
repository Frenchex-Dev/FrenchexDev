namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public interface IRootCommandRequest
{
    IBaseCommandRequest Base { get; }
}