using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Facade;

public class FixCommandFacade : IFixCommandFacade
{
    public FixCommandFacade(
        IFixCommand command,
        IFixCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IFixCommand Command { get; }
    public IFixCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IFixCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();

    public string GetCliCommandName()
    {
        return "fix";
    }
}