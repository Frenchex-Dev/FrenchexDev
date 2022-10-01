using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Request;

public class FixCommandRequest : IFixCommandRequest
{
    public FixCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}