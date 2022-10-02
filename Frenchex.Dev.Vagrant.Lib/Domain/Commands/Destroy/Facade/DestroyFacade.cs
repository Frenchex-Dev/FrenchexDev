using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Facade;

internal class DestroyFacade : IDestroyFacade
{
    public DestroyFacade(IDestroyCommand command, IDestroyCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IDestroyCommand Command { get; }
    public IDestroyCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IDestroyCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}