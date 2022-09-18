using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

public interface IRootCommandRequest
{
    IBaseCommandRequest Base { get; }
}