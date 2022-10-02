using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

public interface IRootCommandRequestBuilder
{
    IBaseCommandRequestBuilder BaseBuilder { get; }
}