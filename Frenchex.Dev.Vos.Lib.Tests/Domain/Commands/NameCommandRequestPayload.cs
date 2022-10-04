using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.Commands;

public class NameCommandRequestPayload
{
    public NameCommandRequestPayload(INameCommandRequest request)
    {
        Request = request;
    }

    public INameCommandRequest Request { get; init; }
    public List<string> ExpectedNames { get; set; } = new();
}