using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Request;

public class InspectCommandRequest : IInspectCommandRequest
{
    public InspectCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}