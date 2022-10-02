using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Facade;

public class InitCommandFacade : IInitCommandFacade
{
    public InitCommandFacade(IInitCommand command, IInitCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "init";
    }

    public IInitCommand Command { get; }
    public IInitCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IInitCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}