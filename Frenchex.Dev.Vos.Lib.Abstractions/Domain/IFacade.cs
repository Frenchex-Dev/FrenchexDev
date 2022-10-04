using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain;

public interface IFacade<out TR1, out TR2, out TR3>
    where TR1 : IAsyncCommand
    where TR2 : IRootCommandRequestBuilderFactory
    where TR3 : IRootCommandRequestBuilder
{
    TR1 Command { get; }
    TR2 RequestBuilderFactory { get; }
    TR3 RequestBuilder { get; }
}
