using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

public interface IRootCommandRequest : IRootCommandRequest<IBaseCommandRequest>
{
}