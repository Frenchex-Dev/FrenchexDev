using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Facade;

public class StatusFacade : IStatusFacade
{
    public StatusFacade(IStatusCommand command, IStatusCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IStatusCommand Command { get; }
    public IStatusCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IStatusCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}