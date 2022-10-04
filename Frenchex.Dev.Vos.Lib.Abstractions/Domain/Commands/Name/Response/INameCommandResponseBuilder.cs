using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

public interface INameCommandResponseBuilder : IRootResponseBuilder
{
    INameCommandResponseBuilder SetNames(string[] names);
    INameCommandResponse Build();
}