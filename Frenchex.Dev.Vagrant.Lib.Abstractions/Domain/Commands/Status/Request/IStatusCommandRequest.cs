using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;

public interface IStatusCommandRequest : IRootCommandRequest
{
    string[] NamesOrIds { get; }
}