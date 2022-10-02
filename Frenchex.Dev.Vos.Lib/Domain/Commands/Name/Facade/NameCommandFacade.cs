using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Facade;

public class NameCommandFacade : INameCommandFacade
{
    public NameCommandFacade(INameCommand command, INameCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "name";
    }

    public INameCommand Command { get; }
    public INameCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public INameCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}