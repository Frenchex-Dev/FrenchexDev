using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Facade;

internal class InitCommandFacade : IInitCommandFacade
{
    public InitCommandFacade(IInitCommand command, IInitCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IInitCommand Command { get; init; }
    public IInitCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IInitCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}