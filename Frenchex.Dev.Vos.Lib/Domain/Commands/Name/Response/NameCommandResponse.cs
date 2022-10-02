using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Response;

public class NameCommandResponse : INameCommandResponse
{
    public NameCommandResponse(string[] names)
    {
        Names = names;
    }

    public string[] Names { get; }
}