using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Facade;

public class InitCommandFacade : IInitCommandFacade
{
    public InitCommandFacade(
        IInitCommand command,
        IInitCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IInitCommand Command { get; }
    public IInitCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IInitCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();

    public string GetCliCommandName()
    {
        return "fmt";
    }
}