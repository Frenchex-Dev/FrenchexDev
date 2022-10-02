using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Facade;

internal class HaltCommandFacade : IHaltCommandFacade
{
    public HaltCommandFacade(IHaltCommand command, IHaltCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IHaltCommand Command { get; }
    public IHaltCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IHaltCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}