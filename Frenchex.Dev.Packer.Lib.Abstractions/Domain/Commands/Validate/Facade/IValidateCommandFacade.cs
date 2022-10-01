using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Facade;

public interface IValidateCommandFacade : IFacableCommand,
    IFacade<IValidateCommand, IValidateCommandRequestBuilderFactory, IValidateCommandRequestBuilder>
{
}