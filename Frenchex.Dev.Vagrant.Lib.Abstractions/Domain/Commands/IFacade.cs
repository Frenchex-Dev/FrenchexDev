using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;

public interface IFacade<out TR1, out TR2, out TR3>
    where TR1 : IFacableCommand
    where TR2 : IRootCommandRequestBuilderFactory
    where TR3 : IRootCommandRequestBuilder
{
    TR1 Command { get; }
    TR2 RequestBuilderFactory { get; }
    TR3 RequestBuilder { get; }
}
