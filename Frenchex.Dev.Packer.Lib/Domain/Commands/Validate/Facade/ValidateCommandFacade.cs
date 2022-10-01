using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Facade;

public class ValidateCommandFacade : IValidateCommandFacade
{
    public ValidateCommandFacade(
        IValidateCommand command,
        IValidateCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }


    public string GetCliCommandName()
    {
        return "Validate";
    }

    public IValidateCommand Command { get; }
    public IValidateCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IValidateCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}