using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Facade;

public class FmtCommandFacade : IFmtCommandFacade
{
    public FmtCommandFacade(
        IFmtCommand command,
        IFmtCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IFmtCommand Command { get; }
    public IFmtCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IFmtCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();

    public string GetCliCommandName()
    {
        return "fmt";
    }
}